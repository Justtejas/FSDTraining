namespace CreationalPatterns.Singleton
{
    internal class Configuration
    {
        private static Configuration _instance;
        private static readonly object _instanceLock = new object();
        public string Setting { get; private set; }
        public Configuration()
        {
            Console.WriteLine("Configuration Loaded");
        }
        public static Configuration Instance
        {
            get
            {
                lock (_instanceLock)
                {
                    _instance ??= new Configuration();
                }
                return _instance;
            }
        }
    }
}
