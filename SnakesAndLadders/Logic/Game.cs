using SnakesAndLadders.Logic.Interface;
using SnakesAndLadders.Models;
using SnakesAndLadders.Models.Enums;
using SnakesAndLadders.Models.Game;
using SnakesAndLadders.Models.Interfaces;

namespace SnakesAndLadders.Logic.Game
{
    /// <summary>
    /// Clase Modelo para Juego
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Último jugador
        /// </summary>
        /// <value></value>
        private PlayerToken _lastPlayer;

        /// <summary>
        /// Estado del juego
        /// </summary>
        /// <value></value>
        private GameState _gameState;

        /// <summary>
        /// Tablero
        /// </summary>
        /// <value></value>
        private readonly Board _board;

        /// <summary>
        /// Tablero
        /// </summary>
        /// <value></value>
        private readonly IDice _dice;

        /// <summary>
        /// Jugadores y Posiciones
        /// </summary>
        /// <value></value>
        private readonly IList<PlayerToken> _playersToken;

        /// <summary>
        /// Constructor crea un tablero con una lita de jugadores y un tablero customisado. 
        /// </summary>
        /// <param name="players"></param>
        /// <param name="board"></param>
        public Game(IList<Player> players, Board board, IDice dice)
        {
            _gameState = GameState.Initializing;
            _board = board;
            _playersToken = GetListPlayerToken(players);
            _dice = dice;
        }

        /// <summary>
        /// Constructor crea un tablero por Defecto  de 10x10 con sus respectivos adornos
        /// </summary>
        /// <param name="players"></param>
        public Game(IList<Player> players, IDice dice)
        {
            _board = GetDefaultBoard();
            _playersToken = GetListPlayerToken(players);
            _gameState = GameState.Initializing;
            _dice = dice;
        }

        /// <summary>
        /// Iniciar Juego y configura las posiciones de los jugadores
        /// </summary>
        public void StartGame()
        {
            Console.WriteLine("Comienza el Juego.....");
            foreach (var playerToken in _playersToken)
                playerToken.Position = 1;
            _gameState = GameState.Playing;
        }

        /// <summary>
        /// Obtiene el resultado del Dado Lanzado
        /// </summary>
        /// <returns></returns>
        public int RollDice()
        => _dice.Throw();

        /// <summary>
        /// Obtien el estado del Juego
        /// </summary>
        /// <returns></returns>
        public GameState GetGameState()
        => _gameState;

        /// <summary>
        /// Obtiene la información del juegador
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public PlayerToken GetPlayerToken(Player player)
        {
            var playerToken = _playersToken.FirstOrDefault(p => p.Player.Id == player.Id);
            playerToken.FellIntoAnOrnament = false;
            return playerToken;
        }

        /// <summary>
        /// Obtiene nueva posición
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="valueDice"></param>
        /// <returns></returns>
        public PlayerToken MovePlayer(Player player, int valueDice)
        {
            var playerToken = GetPlayerToken(player);
            if (playerToken is null)
                throw new Exception("Jugador no encontrado");
            //Configura el último jugador
            _lastPlayer = playerToken;

            if (_gameState != GameState.Playing)
                throw new Exception("Debe iniciar el juego con el método StartGame");

            var newPosition = playerToken.Position + valueDice;
            //Asigna la nueva posición mientras sea menor al número máximo de casillas.
            if (newPosition <= _board.ColumnsSize * _board.RowsSize)
                playerToken.Position = newPosition;

            //Verifica si existe un adorno en la nueva posición
            IAdorned adorned = GetAdornedByPosition(newPosition);
            if (adorned is not null)
            {
                playerToken.FellIntoAnOrnament = true;
                playerToken.AdornedType = adorned.AdornedType;
                playerToken.Position = adorned.EndPosition;
            }
            //Verifica si el jugador ha ganado
            if (newPosition == _board.ColumnsSize * _board.RowsSize)
            {
                playerToken.TokenState = TokenState.Winner;
                _gameState = GameState.Finished;
            }
            return playerToken;
        }

        /// <summary>
        /// Obtiene el siguiente jugador
        /// </summary>
        /// <returns></returns>
        public PlayerToken GetNextPlayer()
        {
            if (!_playersToken.Any())
                throw new Exception("No se ha configurado ningún jugador");
            var nextPlayerPosition = _lastPlayer?.Sequential + 1 ?? 0;
            if (nextPlayerPosition >= _playersToken.Count)
                nextPlayerPosition = 0;
            var nextPlayer = _playersToken.FirstOrDefault(p => p.Sequential == nextPlayerPosition);
            nextPlayer.FellIntoAnOrnament = false;
            return nextPlayer;
        }

        /// <summary>
        /// Verifica si existe un adorno
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns></returns>
        private IAdorned GetAdornedByPosition(int currentPosition)
           => _board.ListAdorned.FirstOrDefault(t => t.StartPosition == currentPosition);

        /// <summary>
        /// Genera la lista de PlayerToken mediante una lista de jugadores
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        private static IList<PlayerToken> GetListPlayerToken(IList<Player> players)
        {
            var listPlayerToken = new List<PlayerToken>();
            for (var i = 0; i < players.Count; i++)
                listPlayerToken.Add(new PlayerToken(players[i], i));
            return listPlayerToken;
        }

        /// <summary>
        /// Configura un tablero por defecto
        /// </summary>
        private static Board GetDefaultBoard()
        {
            var board = new Board(10, 10);
            board.AddSnake(16, 6);
            board.AddSnake(46, 25);
            board.AddSnake(49, 11);
            board.AddSnake(62, 19);
            board.AddSnake(64, 60);
            board.AddSnake(74, 53);
            board.AddSnake(89, 68);
            board.AddSnake(92, 88);
            board.AddSnake(99, 80);
            board.AddLadder(2, 38);
            board.AddLadder(7, 14);
            board.AddLadder(8, 31);
            board.AddLadder(15, 26);
            board.AddLadder(21, 42);
            board.AddLadder(28, 84);
            board.AddLadder(36, 44);
            board.AddLadder(51, 67);
            board.AddLadder(71, 90);
            board.AddLadder(78, 98);
            board.AddLadder(87, 94);
            return board;
        }

    }
}