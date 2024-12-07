namespace _01_HistorianHysteria
{
    internal class Program
    {
        static string INPUTPATH = "Input.txt";

        static int Main(string[] args)
        {
            (var leftList, var rightList) = ReadInput();
            return GetResult(leftList, rightList);
        }

        public static (List<int>, List<int>) ReadInput()
        {
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();

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

            return (leftList, rightList);
        }

        public static int GetResult(List<int> leftList, List<int> rightList) =>
            leftList.Select((x, idx) => Math.Abs(rightList[idx] - x)).Sum();
    }
}
