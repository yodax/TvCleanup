namespace TvCleanup.Tests
{
    using System.Diagnostics;

    public class OutputDouble : AbstractOutput
    {
        protected override void WriteToDevice(string line)
        {
            Debug.WriteLine(line);
        }
    }
}