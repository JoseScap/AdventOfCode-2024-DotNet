using System.Text.RegularExpressions;

namespace _03_MullItOver
{
    internal class Program
    {
        public static string INPUTPATH = "Input.txt";
        public static string PATTERN = @"mul\(\d+,\d+\)";

        public static int Main(string[] args)
        {
            var tuples = ReadInput();
            return GetResult(tuples);
        }

        public static List<(int, int)> ReadInput()
        {
            var tuples = new List<(int, int)>();

            var input = File.ReadLines(INPUTPATH).First();

            MatchCollection matches = Regex.Matches(input, PATTERN);

            foreach (var match in matches)
            {
                var parts = match.ToString().Split(new[] { "mul", "(", ",", ")" }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
                tuples.Add((int.Parse(parts[0]), int.Parse(parts[1])));
            }

            return tuples;
        }

        public static int GetResult(List<(int, int)> tuples)
        {
            return tuples.Sum(x => x.Item1 * x.Item2);
        }
    }
}
