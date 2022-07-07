
using SnakesAndLadders.Logic.Implementation.Dice;
using SnakesAndLadders.Models.Enums;
using SnakesAndLadders.Models.Game;

namespace SnakesAndLadders.Logic.Game
{
    public static class Application
    {
        public static void Init()
        {
            Console.WriteLine("Ingrese Cantidad de Jugadores: ");
            var playersCount = Convert.ToInt32(Console.ReadLine());
            var players = new List<Player>();
            for (var i = 0; i < playersCount; i++)
            {
                Console.WriteLine($"Ingrese Nombre del Jugador N{i + 1}: ");
                var name = Console.ReadLine();
                players.Add(new Player(name));
            }
            var game = new Game(players, new Dice());
            game.StartGame();
            while (game.GetGameState() != GameState.Finished)
            {
                var playerToken = game.GetNextPlayer();
                Console.WriteLine($"Turno del Jugador: {playerToken.Player.Name}");
                Console.WriteLine($"{playerToken.Player.Name} - Presione 'Enter' para Lanzar Dado.");
                Console.ReadLine();
                var valueRoll = game.RollDice();
                Console.WriteLine($"{playerToken.Player.Name} - Posición Actual: {playerToken.Position}");
                Console.WriteLine($"{playerToken.Player.Name} - Valor Obtenido: '{valueRoll}'");
                var newPlayerToken = game.MovePlayer(playerToken.Player, valueRoll);
                if (newPlayerToken.FellIntoAnOrnament)
                    Console.WriteLine($"{newPlayerToken.Player.Name} - Has Caído en una: {newPlayerToken.AdornedType}");
                if (newPlayerToken.TokenState == TokenState.Winner)
                    Console.WriteLine($"¡¡¡FELICIDADES {newPlayerToken.Player.Name} - Has Ganado!!!");
                else
                    Console.WriteLine($"{playerToken.Player.Name} - Nueva Posición es: {playerToken.Position} '\n");
            }
            _ = Console.ReadLine();
        }
    }
}