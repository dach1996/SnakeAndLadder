using SnakesAndLadders.Models.Interfaces;

namespace SnakesAndLadders.Models
{
    /// <summary>
    /// Tablero
    /// </summary>
    public class Board : ModelBase
    {
        /// <summary>
        /// Tamaño de cuadros Horizontal
        /// </summary>
        /// <value></value>
        public int ColumnsSize { get; set; }

        /// <summary>
        /// Tamaño de Cuadros Vertical del tablero
        /// </summary>
        /// <value></value>
        public int RowsSize { get; set; }

        /// <summary>
        /// Lista de Adornos
        /// </summary>
        /// <value></value>
        public IList<IAdorned> ListAdorned { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="columnsSize"></param>
        /// <param name="rowsSize"></param>

        public Board(int columnsSize, int rowsSize)
        {
            ColumnsSize = columnsSize;
            RowsSize = rowsSize;
            ListAdorned = new List<IAdorned>();
        }

        /// <summary>
        /// Agrega Culebras al tablero
        /// </summary>
        /// <param name="adornedTypeCount"></param>
        public void AddSnake(int positionStart, int positionEnd)
        => ListAdorned.Add(new Snake(positionStart, positionEnd));

        /// <summary>
        /// Agrega Culebras al tablero
        /// </summary>
        /// <param name="adornedTypeCount"></param>
        public void AddLadder(int positionStart, int positionEnd)
            => ListAdorned.Add(new Ladder(positionStart, positionEnd));


    }
}