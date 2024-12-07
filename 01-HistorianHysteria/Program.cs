namespace _01_HistorianHysteria
{
    internal class Program
    {
        public static string INPUTPATH = "Input.txt";

        public static int Main(string[] args)
        {
            ReadInput(out var leftList, out var rightList);
            return GetResult(leftList, rightList);
        }

        public static void ReadInput(out List<int> leftList, out List<int> rightList)
        {
            leftList = new List<int>();
            rightList = new List<int>();

            foreach (string line in File.ReadLines(INPUTPATH))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2)
                    {
                        if (int.TryParse(parts[0], out int leftNumber) && int.TryParse(parts[1], out int rightNumber))
                        {
                            leftList.Add(leftNumber);
                            rightList.Add(rightNumber);
                        }
                    }
                }
            }

            leftList.Sort();
            rightList.Sort();
        }

        public static int GetResult(List<int> leftList, List<int> rightList) =>
            leftList.Select((x, idx) => Math.Abs(rightList[idx] - x)).Sum();
    }
}
