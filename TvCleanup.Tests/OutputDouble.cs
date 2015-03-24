namespace TvCleanup.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics;

    public class OutputDouble : IOutput
    {
        public OutputDouble()
        {
            Messages = new List<string>();
        }

        public IList<string> Messages { get; private set; }

        public void WriteLine(string line)
        {
            Messages.Add(line);
            Debug.WriteLine(line);
        }
    }
}