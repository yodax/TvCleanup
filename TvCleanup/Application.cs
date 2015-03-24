namespace TvCleanup
{
    public class Application
    {
        private readonly IOutput output;

        public Application(IOutput output)
        {
            this.output = output;
        }

        public void Start()
        {
            output.WriteLine("Tv clean up");
        }
    }
}