using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8
{
    class Program
    {
        static void Main(string[] args)
        {
            //game initialization code
            int numMoves = 0;
            int playerSpeed = 1;
            Random rand = new Random();
            Entity gameGrid = new Entity();
            Entity player = new Entity();
            Entity monsterSpawner = new Entity();
            Entity speedPowerUpSpawner = new Entity();
            Entity killPowerUpSpawner = new Entity();

            List<Entity> allMonsters = new List<Entity>();
            allMonsters.Add(new Entity());
            allMonsters.Add(new Entity());
            List<Entity> allSpeedPowerUps = new List<Entity>();
            allSpeedPowerUps.Add(new Entity());
            allSpeedPowerUps.Add(new Entity());
            List<Entity> allKillPowerUps = new List<Entity>();
            allKillPowerUps.Add(new Entity());
            allKillPowerUps.Add(new Entity());

            KeyBoardMovement keyBoardInput = new KeyBoardMovement() { speed = playerSpeed };

            foreach (Entity mon in allMonsters)
            {
                mon.Position = new Point { X = rand.Next(8,20), Y = rand.Next(8, 20) };
                mon.AddComponent(new KillPlayerComponent(player));
                mon.AddComponent(new AIStandardMovementComponent(player));
                mon.AddComponent(new KeepInBoundsComponent(19, 19));
            }
            foreach(Entity power in allSpeedPowerUps)
            {
                power.Position = new Point { X = rand.Next(5, 15), Y = rand.Next(5, 15) };
                power.AddComponent(new CollideWithPlayerComponent(player,allSpeedPowerUps, new SpeedPowerUpConponent(keyBoardInput)));
            }
            foreach(Entity power in allKillPowerUps)
            {
                power.Position = new Point { X = rand.Next(15, 19), Y = rand.Next(0, 19) };
                power.AddComponent(new CollideWithPlayerComponent(player, allKillPowerUps, new KillPowerUpConponent(allMonsters)));
            }
           
            player.AddComponent(new KillMonsterComponent(allMonsters));
            player.AddComponent(new KeepInBoundsComponent(19, 19));
            player.AddComponent(keyBoardInput);

            monsterSpawner.AddComponent(new MonsterSpawnerConponent(player, allMonsters));
            speedPowerUpSpawner.AddComponent(new PowerUpSpawnerComponent(player, allSpeedPowerUps, new CollideWithPlayerComponent(player, allSpeedPowerUps, new SpeedPowerUpConponent(keyBoardInput))));
            killPowerUpSpawner.AddComponent(new PowerUpSpawnerComponent(player, allKillPowerUps, new CollideWithPlayerComponent(player, allKillPowerUps, new KillPowerUpConponent(allMonsters))));

            gameGrid.AddComponent(new DrawGrid(20, 20, player, allMonsters,allSpeedPowerUps,allKillPowerUps));
            //----
            //Instructions
            Console.WriteLine("=================| INSTRUCTIONS |==================");
            Console.WriteLine("Rules:");
            Console.WriteLine("stay alive as long as you can by killing and running");
            Console.WriteLine("away from the monsters. Collect powerups to help you");
            Console.WriteLine("survive!");
            Console.WriteLine("");
            Console.WriteLine("Controls/How to play:");
            Console.WriteLine("Use WASD to move around and press SPACEBAR to not move/stand still");
            Console.WriteLine("If a monster is 1 space next to you, you can move on top of them to ");
            Console.WriteLine("kill them. If you move onto a space that a monster is about to move");
            Console.WriteLine("onto then you die.");
            Console.WriteLine("");
            Console.WriteLine("[P] - represents the player");
            Console.WriteLine("[M] - represents the a monster");
            Console.WriteLine("[S] - represents the speed powerup. Collect these to move 2 spaces");
            Console.WriteLine("      instead of only one");
            Console.WriteLine("[K] - represents the kill powerup. Collect them to kill all monsters");
            Console.WriteLine("      near the player.");
            Console.WriteLine("");
            Console.WriteLine("=========| Press ENTER to begin the game |=========");
            string start = Console.ReadLine();
            //----
            //gameloop
            while (true)
            {
                Console.WriteLine(player.Position);
                player.Update();
                for (int i = 0; i < allMonsters.Count; i++)
                {
                    allMonsters[i].Update();
                }
                for (int i = 0; i < allSpeedPowerUps.Count; i++)
                {
                    allSpeedPowerUps[i].Update();
                }
                for (int i = 0; i < allKillPowerUps.Count; i++)
                {
                    allKillPowerUps[i].Update();
                }
                
                monsterSpawner.Update();
                //speedPowerUpSpawner.Update();
                //killPowerUpSpawner.Update();
                gameGrid.Update();
                numMoves++;
            }
            //----
        }
    }


    
}
