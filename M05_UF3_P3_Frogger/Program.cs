using System;
using System.Collections.Generic;
using System.Linq;


namespace M05_UF3_P3_Frogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Player player = new Player();

            List<Lane> lanes = new List<Lane>();
            lanes.Add(new Lane(0, false, ConsoleColor.DarkGreen, false, false, 0.0f, ' ', new List<ConsoleColor>() {ConsoleColor.Green}));
            lanes.Add(new Lane(1, true, ConsoleColor.Blue, false, true, 0.6f, Utils.charLogs, new List<ConsoleColor>() { Utils.colorsLogs[0], Utils.colorsLogs[1] }));
            lanes.Add(new Lane(2, true, ConsoleColor.Blue, false, true, 0.6f, Utils.charLogs, new List<ConsoleColor>() { Utils.colorsLogs[0], Utils.colorsLogs[1] }));
            lanes.Add(new Lane(3, true, ConsoleColor.Blue, false, true, 0.6f, Utils.charLogs, new List<ConsoleColor>() { Utils.colorsLogs[0], Utils.colorsLogs[1] }));
            lanes.Add(new Lane(4, true, ConsoleColor.Blue, false, true, 0.6f, Utils.charLogs, new List<ConsoleColor>() { Utils.colorsLogs[0], Utils.colorsLogs[1] }));
            lanes.Add(new Lane(5, true, ConsoleColor.Blue, false, true, 0.6f, Utils.charLogs, new List<ConsoleColor>() { Utils.colorsLogs[0], Utils.colorsLogs[1] }));
            lanes.Add(new Lane(6, false, ConsoleColor.DarkGreen, false, false, 0.0f, ' ', new List<ConsoleColor>() { ConsoleColor.Green}));
            lanes.Add(new Lane(7, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, new List<ConsoleColor>() { Utils.colorsCars[0], Utils.colorsCars[1], Utils.colorsCars[2], Utils.colorsCars[3] }));
            lanes.Add(new Lane(8, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, new List<ConsoleColor>() { Utils.colorsCars[0], Utils.colorsCars[1], Utils.colorsCars[2], Utils.colorsCars[3] }));
            lanes.Add(new Lane(9, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, new List<ConsoleColor>() { Utils.colorsCars[0], Utils.colorsCars[1], Utils.colorsCars[2], Utils.colorsCars[3] }));
            lanes.Add(new Lane(10, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, new List<ConsoleColor>() { Utils.colorsCars[0], Utils.colorsCars[1], Utils.colorsCars[2], Utils.colorsCars[3] }));
            lanes.Add(new Lane(11, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, new List<ConsoleColor>() { Utils.colorsCars[0], Utils.colorsCars[1], Utils.colorsCars[2], Utils.colorsCars[3] }));
            lanes.Add(new Lane(12, false, ConsoleColor.DarkGreen, false, false, 0.0f, ' ', new List<ConsoleColor>() {ConsoleColor.Green}));

            Utils.GAME_STATE gameState = Utils.GAME_STATE.RUNNING;

            ConsoleColor background = Console.BackgroundColor;

            while (gameState == Utils.GAME_STATE.RUNNING)
            {

                for (int i = 0; i < lanes.Count; i++)
                {
                    lanes[i].Update();
                    Console.BackgroundColor = ConsoleColor.Black;
                    lanes[i].Draw();
                }

                Vector2Int dir = Utils.Input();
                gameState = player.Update(dir, lanes);
                player.Draw(lanes);

                Console.BackgroundColor = background;

                TimeManager.NextFrame(); ;
            }

            if (gameState == Utils.GAME_STATE.WIN)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("¡Has ganado! ;)");
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡Has perdido! ;(");
            }
            Console.ReadKey();
        }
    }
}