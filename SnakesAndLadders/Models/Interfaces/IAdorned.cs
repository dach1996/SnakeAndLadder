using SnakesAndLadders.Models.Enums;

namespace SnakesAndLadders.Models.Interfaces
{
    /// <summary>
    /// Adornos que pueden existir
    /// </summary>
    public interface IAdorned
    {
        /// <summary>
        /// Posición Inicial
        /// </summary>
        /// <value></value>
        int StartPosition { get; set; }

        /// <summary>
        /// Posición Final
        /// </summary>
        /// <value></value>
        int EndPosition { get; set; }

        /// <summary>
        /// Tipo de Funcionalidad de Adorno
        /// </summary>
        /// <value></value>
        FuntionalityAdornedType FuntionalityAdornedType { get; }

        /// <summary>
        /// Tipo de Adorno del Tablero
        /// </summary>
        /// <value></value>
        AdornedType AdornedType { get; }
    }
}