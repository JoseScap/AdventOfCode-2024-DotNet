string inputPath = "Input.txt";

List<int> leftList = new List<int>();
List<int> rightList = new List<int>();

foreach (string line in File.ReadLines(inputPath))
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

var result = leftList.Select((x, idx) => Math.Abs(rightList[idx] - x)).Sum();

Console.WriteLine($"Result: {result}");
Console.WriteLine("Exit");