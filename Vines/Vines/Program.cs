using System;

namespace Vines
{
    public partial class Program
    {        
        public static void Main()
        {            
            GameStart();
        }

        static void GameStart()
        {
            Console.Clear();
            Console.Write("\n          VINES\n\n  Press enter to play  \n  Type 'Help' for info\n\n");
            string input = Console.ReadLine();
            if (String.Equals(input, "help", StringComparison.OrdinalIgnoreCase))
            {
                help();
            }
            InitiateNewGame();
        }

        static void help()
        {
            Console.Clear();
            Console.Write(" The goal of vines is to get each vine to grow to the light. \n\n" +
                "Each vine is numbered and starts on a square indicated by it's respective number.\n" +
                "A vine will begin by growing as close to upwards as possible. When a vine hits an obstruction it will change direction.\n" +
                "Vines that are odd numbered will prioritize turning left while even numbered vines will prioritize turning right.\n" +
                "Vines cannot grow on a square that another vine has grown on. And vines will continue to grow in the same direction until obstructed.\n" +
                "If a vine hits an obstruction and cannot turn left or right then it will die. \n" +
                "If any vine dies then you lose a life.\n" +
                "Lose all lives and the game ends.\n\n" +
                "Vines will only begin growing when the player initiates their growth.\n" +
                "A vine begins growing when the player inputs the number of a vine.\n" +
                "Only one number may be inputed at a time. However multiple vines may be numbered the same.\n" +
                "You cannot initiate the growth of a vine while another vine is currently growing.\n\n" +
                "Light squares are designated by the letter 'L.'\n\n");
            Console.ReadLine();
            Console.Clear();
            GameStart();
        }

        static void InitiateNewGame()
        {
            Console.Clear();
            MainGameLoop theGame = new MainGameLoop();
            theGame.newGame();
        }
    }
}
