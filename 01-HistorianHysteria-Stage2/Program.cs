namespace _01_HistorianHysteria_Stage2
{
    internal class Program
    {
        public static string INPUTPATH = "Input.txt";

        public static int Main(string[] args)
        {
            (var leftList, var rightList) = ReadInput();
            var dictionary = MakeDictionary(leftList, rightList);
            return GetResult(dictionary);
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

        public static Dictionary<int, Match> MakeDictionary(List<int> leftList, List<int> rightList)
        {
            var dictionary = new Dictionary<int, Match>();
            
            foreach (int leftNumber in leftList)
            {
                if (!dictionary.ContainsKey(leftNumber)) dictionary.Add(leftNumber, new());
                dictionary[leftNumber].leftCount++;
            }

            foreach (int rightNumber in rightList)
            {
                if (dictionary.ContainsKey(rightNumber))
                {
                    dictionary[rightNumber].rightCount++;
                }
            }

            return dictionary;
        }
    
        public static int GetResult(Dictionary<int, Match> dictionary)
        {
            var result = 0;

            foreach (var kvp in dictionary)
            {
                result += kvp.Key * kvp.Value.rightCount * kvp.Value.leftCount;
            }

            return result;
        }
    }

    internal class Match
    {
        public int leftCount = 0;
        public int rightCount = 0;
    }
}
