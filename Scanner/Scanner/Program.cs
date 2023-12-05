namespace Scanner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a sequence of tokens:");
            string input = Console.ReadLine();
            string[] tokens = input.Split(' ');

            int line = 1;

            foreach (string token in tokens)
            {
                if (!string.IsNullOrWhiteSpace(token))
                {
                    TokenProcessor.ScanToken(token, ref line);
                }
            }
        }
    }
}
