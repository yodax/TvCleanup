namespace TvCleanup
{
    using System;

    public class Output : IOutput
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}