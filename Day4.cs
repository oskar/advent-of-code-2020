using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace advent_of_code_2020
{
    public class Day4 : IDay
    {
        public long PartOne(string[] input)
        {
            return GetPassportLines(input)
                .Select(l => Regex.Matches(l, @"(\w{3}):\S*")
                    .Select(m => m.Groups[1].Value)
                    .ToHashSet())
                .Count(set => set.Contains("byr") &&
                              set.Contains("iyr") &&
                              set.Contains("eyr") &&
                              set.Contains("hgt") &&
                              set.Contains("hcl") &&
                              set.Contains("ecl") &&
                              set.Contains("pid"));
        }

        public long PartTwo(string[] input)
        {
            return GetPassportLines(input)
                .Select(l => Regex.Matches(l, @"(\w{3}):(\S*)")
                    .ToDictionary(m => m.Groups[1].Value, m => m.Groups[2].Value))
                .Where(p => p.TryGetValue("byr", out var birthYear) && BirthYearIsValid(birthYear))
                .Where(p => p.TryGetValue("iyr", out var issueYear) && IssueYearIsValid(issueYear))
                .Where(p => p.TryGetValue("eyr", out var expirationYear) && ExpirationYearIsValid(expirationYear))
                .Where(p => p.TryGetValue("hgt", out var height) && HeightIsValid(height))
                .Where(p => p.TryGetValue("hcl", out var hairColor) && HairColorIsValid(hairColor))
                .Where(p => p.TryGetValue("ecl", out var eyeColor) && EyeColorIsValid(eyeColor))
                .Count(p => p.TryGetValue("pid", out var passportId) && PassportIsIsValid(passportId));
        }

        private static bool BirthYearIsValid(string input) => int.Parse(input) is >= 1920 and <= 2002;
        private static bool IssueYearIsValid(string input) => int.Parse(input) is >= 2010 and <= 2020;
        private static bool ExpirationYearIsValid(string input) => int.Parse(input) is >= 2020 and <= 2030;

        private static bool HeightIsValid(string input)
            => input.Substring(input.Length - 2) switch
            {
                "cm" => int.TryParse(input.Substring(0, input.Length - 2), out var number) &&
                        number is >= 150 and <= 193,
                "in" => int.TryParse(input.Substring(0, input.Length - 2), out var number) &&
                        number is >= 59 and <= 76,
                _ => false
            };

        private static bool HairColorIsValid(string input) => Regex.IsMatch(input, @"^#[\da-f]{6}$");

        private static bool EyeColorIsValid(string input)
            => input is "amb" or "blu" or "brn" or "gry" or "grn" or "hzl" or "oth";

        private static bool PassportIsIsValid(string input) => Regex.IsMatch(input, @"^[0-9]{9}$");

        private static IEnumerable<string> GetPassportLines(IEnumerable<string> input)
        {
            var currentPassport = "";

            foreach (var line in input)
            {
                if (line == "")
                {
                    yield return currentPassport;
                    currentPassport = "";
                }
                else
                {
                    currentPassport += " " + line;
                }
            }

            if (currentPassport != string.Empty)
            {
                yield return currentPassport;
            }
        }
    }
}