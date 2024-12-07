namespace _02_Red_Nosed_Reports
{
    internal class Program
    {
        public static string INPUTPATH = "Input.txt";

        public static int Main(string[] args)
        {
            var reports = ReadInput();
            return GetResult(reports);
        }

        public static List<List<int>> ReadInput()
        {
            var input = new List<List<int>>();

            foreach (string line in File.ReadLines(INPUTPATH))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => int.Parse(x))
                        .ToList();
                    input.Add(parts);
                }
            }

            return input;
        }

        public static int GetResult(List<List<int>> reports)
        {
            var safeReportsCount = 0;

            foreach (var report in reports)
            {
                if (report[0] == report[1]) continue;
                var isAscending = report[0] < report[1];
                var aux = 0;
                var safe = true;

                foreach (var item in report)
                {
                    if (aux == 0) { 
                        aux = item;
                        continue;
                    }
                    
                    var diff = item - aux;
                    if ( (isAscending && (diff > 3 || diff <= 0)) || (!isAscending && (diff < -3 || diff >= 0)) )
                    {
                        safe = false;
                        break;
                    }
                    aux = item;
                }

                if (safe) safeReportsCount++;
            }

            return safeReportsCount;
        }
    }
}
