namespace TvCleanup
{
    using System;

    public class Output : AbstractOutput
    {
        protected override void WriteToDevice(string line)
        {
            Console.WriteLine(line);
        }
    }
}