namespace TvCleanup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Resolve().For<Application>().Start();
        }
    }
}