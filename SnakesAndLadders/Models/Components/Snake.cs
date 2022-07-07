using SnakesAndLadders.Models.Enums;
using SnakesAndLadders.Models.Interfaces;

namespace SnakesAndLadders.Models
{
    /// <summary>
    /// Serpientes
    /// </summary>
    public class Snake : ModelBase, IAdorned

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
        public FuntionalityAdornedType FuntionalityAdornedType { get => FuntionalityAdornedType.Back; }

        /// <summary>
        /// Adorno de tipo Culebra
        /// </summary>
        /// <returns></returns>
        public AdornedType AdornedType => AdornedType.Snake;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="endPosition"></param>
        public Snake(int startPosition, int endPosition)
        {
            StartPosition = startPosition;
            EndPosition = endPosition;
        }
    }
}