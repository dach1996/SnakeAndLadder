using SnakesAndLadders.Logic.Interface;

namespace SnakesAndLadders.Logic.Implementation.Dice
{
    /// <summary>
    /// Dado simulador para Test
    /// </summary>
    public class DiceMock : IDice
    {
        /// <summary>
        /// Lista de valores permitidos
        /// </summary>
        private readonly List<int> _listIntAllow;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="listIntAllow"></param>
        public DiceMock()
        {
            _listIntAllow = new List<int>();
        }

        /// <summary>
        /// Configura valores a la Lista permitida para el dado simulado
        /// </summary>
        /// <param name="valuesAllow"></param>
        public void SetValuesAllow(params int[] valuesAllow)
        {
            _listIntAllow.Clear();
            _listIntAllow.AddRange(valuesAllow);
        }

        /// <summary>
        /// Lanzar dado
        /// </summary>
        /// <returns></returns>
        public int Throw()
        {
            var random = new Random();
            var randomPosition = random.Next(_listIntAllow.Count);
            return _listIntAllow[randomPosition];
        }
    }
}