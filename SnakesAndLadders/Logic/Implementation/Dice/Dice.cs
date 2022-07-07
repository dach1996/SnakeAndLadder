using SnakesAndLadders.Logic.Interface;

namespace SnakesAndLadders.Logic.Implementation.Dice

{
    /// <summary>
    /// Dado
    /// </summary>
    public class Dice : IDice
    {
        private readonly Random _random = new();

        /// <summary>
        /// Tamaño de cuadros Horizontal
        /// </summary>
        /// <value></value>
        public int SidesNumber { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sidesNumber"></param>
        /// <param name="squareVerticalNumberSize"></param>

        public Dice(int sidesNumber = 7)
        => SidesNumber = sidesNumber;

        /// <summary>
        /// Lanzar Dado
        /// </summary>
        /// <returns></returns>
        public int Throw()
        => _random.Next(1, SidesNumber);

    }
}