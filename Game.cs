using System;
using GameCore.Base;
using GameCore.Classes;

namespace GameCore {

    class Game {
        
        // Fields
        DateTime lastRefresh = DateTime.Now;
        int refreshInterval = 1000; // 1000ms = 1 second

        public void Run() {
            
            Character player = new Warrior();

            while (true) { // Game Loop
                
                if ((DateTime.Now - lastRefresh).TotalMilliseconds >= refreshInterval) {

                    Console.Clear(); // clears the screen each loop

                    // Stats Display
                    Console.WriteLine("The game is running!");
                    Console.WriteLine("HP: " + player.currentHealth + " / " + player.maxHealth); // Display players HP
                    Console.WriteLine("MP: " + player.currentMana + " / " + player.maxMana); // Display players MP

                    Console.WriteLine("\n\n\n\n\n\n\n");

                    if (player.currentHealth <= 0) {

                        Console.WriteLine("You died!");
                        break;
                    }

                    lastRefresh = DateTime.Now;

                    System.Threading.Thread.Sleep(500); // 50ms pause to lower CPU usage
                }
            }
        }

        public void Input() {

            
        }
    }
}
