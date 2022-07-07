using SnakesAndLadders.Models.Enums;

namespace SnakesAndLadders.Models.Game
{
    /// <summary>
    /// Clase modelo para uso de Posiciones por Juegador
    /// </summary>
    public class PlayerToken
    {
        /// <summary>
        /// Secuencial
        /// </summary>
        /// <value></value>
        public long Sequential { get; set; }

        /// <summary>
        /// Jugadores
        /// </summary>
        /// <value></value>
        public Player Player { get; set; }

        /// <summary>
        /// Token 
        /// </summary>
        /// <value></value>
        public int Position { get; set; }

        /// <summary>
        /// Estado del Jugador
        /// </summary>
        /// <value></value>
        public TokenState TokenState { get; set; }

        /// <summary>
        /// Cayó en un adorno
        /// </summary>
        /// <value></value>
        public bool FellIntoAnOrnament { get; set; }

        /// <summary>
        /// Tipo de Adorno
        /// </summary>
        /// <value></value>
        public AdornedType AdornedType { get; set; }

        /// <summary>
        /// Constructor recibe un jugador
        /// </summary>
        /// <param name="player"></param>
        /// <param name="sequential"></param>
        public PlayerToken(Player player, long sequential)
        {
            Player = player;
            Sequential = sequential;
            TokenState = TokenState.Playing;
        }
    }
}