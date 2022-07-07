using SnakesAndLadders.Models.Enums;
using SnakesAndLadders.Models.Interfaces;

namespace SnakesAndLadders.Models
{
    /// <summary>
    /// Escalera
    /// </summary>
    public class Ladder : ModelBase, IAdorned
    {
        /// <summary>
        /// Posición Inicial
        /// </summary>
        /// <value></value>
        public int StartPosition { get; set; }

        /// <summary>
        /// Posición Final
        /// </summary>
        /// <value></value>
        public int EndPosition { get; set; }

        /// <summary>
        /// Tipo de Adorno del Tablero
        /// </summary>
        /// <value></value>
        public FuntionalityAdornedType FuntionalityAdornedType { get => FuntionalityAdornedType.Advance; }

        /// <summary>
        /// Adorno de tipo escalera
        /// </summary>
        public AdornedType AdornedType => AdornedType.Ladder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="endPosition"></param>
        public Ladder(int startPosition, int endPosition)
        {
            StartPosition = startPosition;
            EndPosition = endPosition;
        }
    }
}