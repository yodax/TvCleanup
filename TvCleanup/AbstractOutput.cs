namespace TvCleanup
{
    using System.Collections.Generic;

    public abstract class AbstractOutput
    {
        protected AbstractOutput()
        {
            Messages = new List<string>();
        }

        public IList<string> Messages { get; private set; }

        public void WriteLine(string line)
        {
            Messages.Add(line);
            WriteToDevice(line);
        }

        protected abstract void WriteToDevice(string line);
    }
}