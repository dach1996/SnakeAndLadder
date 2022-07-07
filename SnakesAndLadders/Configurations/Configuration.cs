namespace SnakesAndLadders.Configurations
{
    public class ConfigurationSingleton
    {
        private ConfigurationSingleton() { }
        private static readonly ConfigurationSingleton instance = null;
        public static ConfigurationSingleton Instance
        {
            get => instance ?? new ConfigurationSingleton()
            {
                MaxSnakes = 8,
                MaxLadder = 9
            };
        }

        /// <summary>
        /// Máximo de culebras
        /// </summary>
        /// <value></value>
        public int MaxSnakes { get; private set; }

        /// <summary>
        /// Máximo de Escaleras
        /// </summary>
        /// <value></value>
        public int MaxLadder { get; private set; }

    }
}