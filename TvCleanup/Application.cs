namespace TvCleanup
{
    public class Application
    {
        private readonly AbstractOutput abstractOutput;

        public Application(AbstractOutput abstractOutput)
        {
            this.abstractOutput = abstractOutput;
        }

        public void Start()
        {
            abstractOutput.WriteLine("Tv clean up");
        }
    }
}