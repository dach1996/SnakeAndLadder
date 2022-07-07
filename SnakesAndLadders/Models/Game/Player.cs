namespace SnakesAndLadders.Models.Game
{
    /// <summary>
    /// Clase modelo para Jugador
    /// </summary>
    public class Player
    {

        /// <summary>
        /// Id
        /// </summary>
        /// <value></value>
        public string Id { get; set; }

        /// <summary>
        /// Nombre del Jugador
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Player(string name)
        {
            Name = name;
            Id = Guid.NewGuid().ToString();
        }
    }
}