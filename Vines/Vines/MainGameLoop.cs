using System;
using System.Collections.Generic;
using System.Text;

namespace Vines
{
    public partial class MainGameLoop
    {
        Grid currentLevel;
        int lives = 5;
        int stage;
        bool pause = true;
        int framePause = 300;

        public void newGame()
        {
            lives = 5;
            currentLevel = new Grid(levelToGrid(levelPool[0]),levelPool[0]);

            for ( int i = 1; i < levelPool.Length; i++ )
            {
                stage = i;
                currentLevel = new Grid(levelToGrid(levelPool[i]),levelPool[i]);
                if (!levelLoop()){ Program.Main(); }
            }

            Program.Main();
        }

        public bool levelLoop()
        {
            Console.Clear();
            Console.Write("     VINES!\n\n    Level: " + stage + "\n  Lives Left: " + lives+"\n");
            if (currentLevel.checkGrowth())
            {
                currentLevel.draw(false);
                if (pause) { System.Threading.Thread.Sleep(framePause); }
                if (currentLevel.areDeadPlants())
                {
                    lives -= 1;
                    if (lives == 1) { Console.Write("  A plant has failed to grow into the light and died! \n  You have " + lives + " life left."); }
                    else { Console.Write("  A plant has failed to grow into the light and died! \n  You have " + lives + " lives left."); }                    
                    Console.ReadLine();

                    if (lives <=0)
                    {
                        Console.Write("\n You have no lives left and have lost the game! You must try again from the start!");
                        Console.ReadLine();
                        return false;
                    }
                    
                    currentLevel.resetLevel();
                    return levelLoop();
                }

                return levelLoop();
            }

            currentLevel.clearGrowingPlants();
            currentLevel.draw(false);

            if (!currentLevel.checkPlants())
            {
                Console.Write("        Success!   \n  All plants have grown to the light!\n    Press enter to continue.\n");
                Console.ReadLine();                
                return true;
            }

            Console.Write("  Select a plant to grow: ");
            currentLevel.growingPlants = currentLevel.getPlant();
            currentLevel.startGrowth();
            return levelLoop();
            
        }
    }
}
