using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8
{
    class Component
    {
        public virtual void Update() { }
        public Entity EntityParent { get; set; }
    }
    class KeyBoardMovement : Component
    {
        public int speed { get; set; }
        public KeyBoardMovement()
        {

        }
        public override void Update()
        {
            Console.Write("Which way do you want to move? (WASD to move SPACEBAR to stand still): ");
            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (choice)
            {
                case 'w':
                    EntityParent.Position.Y-=speed;
                    break;
                case 'a':
                    EntityParent.Position.X-=speed;
                    break;
                case 's':
                    EntityParent.Position.Y+=speed;
                    break;
                case 'd':
                    EntityParent.Position.X+=speed;
                    break;
                default:
                    break;
            }
        }
    }
    class AIStandardMovementComponent : Component
    {
        Entity player;
        public AIStandardMovementComponent(Entity player)
        {
            this.player = player;
        }
        public override void Update()
        {
            if (EntityParent.Position.X == player.Position.X && EntityParent.Position.Y == player.Position.Y)
            {

            }
            else
            {
                if (Math.Abs(EntityParent.Position.X - player.Position.X) > Math.Abs(EntityParent.Position.Y - player.Position.Y))
                {
                    //move in X
                    if (EntityParent.Position.X > player.Position.X)
                    {
                        EntityParent.Position.X--;
                    }
                    else
                    {
                        EntityParent.Position.X++;
                    }
                }
                else
                {
                    //move in Y
                    if (EntityParent.Position.Y > player.Position.Y)
                    {
                        EntityParent.Position.Y--;
                    }
                    else
                    {
                        EntityParent.Position.Y++;
                    }
                }
            }
               


        }
    }
    class AIDiagonalMovementComponent : Component
    {
        Entity player;
        public AIDiagonalMovementComponent(Entity player)
        {
            this.player = player;
        }
        public override void Update()
        {
            //move in X
            if (EntityParent.Position.X > player.Position.X)
            {
                EntityParent.Position.X--;
            }
            else
            {
                EntityParent.Position.X++;
            }
            //move in Y
            if (EntityParent.Position.Y > player.Position.Y)
            {
                EntityParent.Position.Y--;
            }
            else
            {
                EntityParent.Position.Y++;
            }
        }
    }
    class DrawGrid : Component
    {
        int[,] coordinatePlane;
        Entity player;
        List<Entity> monsters;
        List<Entity> speedPowerUps;
        List<Entity> killPowerUps;
        public DrawGrid(int xSize, int ySize, Entity player, List<Entity> monsters, List<Entity> speedPowerUps, List<Entity> killPowerUps)
        {
            coordinatePlane = new int[xSize, ySize];
            this.player = player;
            this.monsters = monsters;
            this.speedPowerUps = speedPowerUps;
            this.killPowerUps = killPowerUps;
        }
        public override void Update()
        {
            Console.Clear();
            for (int col = 0; col < 20; col++)
            {
                for (int row = 0; row < 20; row++)
                {
                    if (player.Position.X == row && player.Position.Y == col)
                    {
                        Console.Write("[P]");
                    }
                    else if (!DrawGroup(monsters, row, col,"[M]") && !DrawGroup(speedPowerUps, row, col, "[S]") && !DrawGroup(killPowerUps, row, col, "[K]"))
                    {
                        Console.Write("[ ]");
                    }
                }
                Console.WriteLine();
            }
        }
        private bool DrawGroup(List<Entity> list, int targetX, int targetY, string text)
        {
            foreach (Entity ent in list)
            {
                if (ent.Position.X == targetX && ent.Position.Y == targetY)
                {
                    Console.Write(text);
                    return true;
                }
            }
            return false;
        }
    }
    class KillPlayerComponent : Component
    {
        Entity player;
        public KillPlayerComponent(Entity player)
        {
            this.player = player;
        }
        public override void Update()
        {
            if (player.Position.X == EntityParent.Position.X && player.Position.Y == EntityParent.Position.Y)
            {
                Console.Clear();
                Console.WriteLine("Game Over! A Monster has slain the player");
                Console.ReadLine();
            }
        }
    }
    class KillMonsterComponent : Component
    {
        List<Entity> monsterList;
        public KillMonsterComponent(List<Entity> monsterList)
        {
            this.monsterList = monsterList;
        }
        public override void Update()
        {
            foreach(Entity monster in monsterList)
            {
                if (monster.Position.X == EntityParent.Position.X && monster.Position.Y == EntityParent.Position.Y)
                {
                    monsterList.Remove(monster);
                    break;
                }
            }

        }
    }
    class KeepInBoundsComponent : Component
    {
        int maxX, maxY;
        public KeepInBoundsComponent(int maxX, int maxY)
        {
            this.maxX = maxX;
            this.maxY = maxY;
        }
        public override void Update()
        {
            //X direction
            if (EntityParent.Position.X >= maxX)
            {
                EntityParent.Position.X = maxX;
            }
            else if(EntityParent.Position.X <= 0)
            {
                EntityParent.Position.X = 0;
            }
            //Y direction
            if (EntityParent.Position.Y >= maxY)
            {
                EntityParent.Position.Y = maxY;
            }
            else if (EntityParent.Position.Y <= 0)
            {
                EntityParent.Position.Y = 0;
            }
        }

    }
    class CollideWithPlayerComponent : Component
    {
        Component comp;
        Entity player;
        List<Entity> list;
        public CollideWithPlayerComponent(Entity player, List<Entity> container, Component addedComponent)
        {
            comp = addedComponent;
            this.player = player;
            list = container;
        }
        public override void Update()
        {
            if (EntityParent.Position.X == player.Position.X && EntityParent.Position.Y == player.Position.Y)
            {
                player.AddComponent(comp);
                list.Remove(EntityParent);
            }
        }
    }
    class SpeedPowerUpConponent : Component
    {
        int turnCounter;
        KeyBoardMovement keyboard;
        public SpeedPowerUpConponent(KeyBoardMovement keyboard)
        {
            this.keyboard = keyboard;
            turnCounter = 0;
        }
        public override void Update()
        {
            turnCounter++;
            keyboard.speed = 2;
            if(turnCounter >= 5)
            {
                keyboard.speed = 1;
                EntityParent.RemoveComponent(this);
            }
        }
    }
    class KillPowerUpConponent : Component
    {
        List<Entity> monsters;
        public KillPowerUpConponent(List<Entity> monsters)
        {
            this.monsters = monsters;
        }
        public override void Update()
        {
            for(int i = 0; i < monsters.Count; i++)
            {
                if(Math.Abs(monsters[i].Position.X - EntityParent.Position.X) <= 10 && Math.Abs(monsters[i].Position.Y - EntityParent.Position.Y) <= 10)
                {
                    monsters.Remove(monsters[i]);
                    i--;
                }
            }
            EntityParent.RemoveComponent(this);
        }
    }
    class MonsterSpawnerConponent : Component
    {
        Random rand;
        int turnCounter;
        int increment;
        int desiredTurn;
        List<Entity> monsterList;
        Entity player;
        public MonsterSpawnerConponent(Entity player, List<Entity> monsterList)
        {
            turnCounter = 0;
            this.monsterList = monsterList;
            this.player = player;
            desiredTurn = 8;
            rand = new Random();
            increment = 6;

        }
        public override void Update()
        {
            turnCounter++;
            if(turnCounter == desiredTurn)
            {
                if (desiredTurn == 25)
                    increment--;
                if (desiredTurn == 40)
                    increment--;
                if (desiredTurn == 50)
                    increment--;
                desiredTurn += increment;
                Entity addedMonster = new Entity();
                switch (rand.Next(0, 4))
                {
                    case 0:
                        addedMonster.Position = new Point { X = rand.Next(0, 20), Y = 0 };
                        break;
                    case 1:
                        addedMonster.Position = new Point { X = 19, Y = rand.Next(0, 20) };
                        break;
                    case 2:
                        addedMonster.Position = new Point { X = rand.Next(0, 20), Y = 19 };
                        break;
                    case 3:
                        addedMonster.Position = new Point { X = 0, Y = rand.Next(0, 20) };
                        break;
                }
                addedMonster.AddComponent(new KillPlayerComponent(player));
                addedMonster.AddComponent(new AIStandardMovementComponent(player));
                addedMonster.AddComponent(new KeepInBoundsComponent(19, 19));
                monsterList.Add(addedMonster);
            }
        }
    }
    class PowerUpSpawnerComponent : Component
    {
        Random rand;
        int turnCounter;
        int desiredTurn;
        List<Entity> powerupList;
        Entity player;
        CollideWithPlayerComponent addedComponent;
        Entity addedPowerUp;
        public PowerUpSpawnerComponent(Entity player, List<Entity> powerupList, CollideWithPlayerComponent addedComponent)
        {
            turnCounter = 0;
            this.powerupList = powerupList;
            this.player = player;
            this.addedComponent = addedComponent;
            desiredTurn = 2;
            rand = new Random();
        }
        public override void Update()
        {
            turnCounter++;
            if (turnCounter == desiredTurn)
            {
                desiredTurn += 8;
                int xPos = rand.Next(-15, 15) + player.Position.X, yPos = rand.Next(-15, 15) + player.Position.Y;

                addedPowerUp = new Entity();
                while (xPos < 0 || xPos > 19)
                {
                    xPos = rand.Next(-15, 15) + player.Position.X;
                }

                while (yPos < 0 || yPos > 19)
                {
                    yPos = rand.Next(-15, 15) + player.Position.Y;
                }
                addedPowerUp.Position = new Point { X = xPos, Y = yPos };
                addedPowerUp.AddComponent(addedComponent);
                powerupList.Add(addedPowerUp);
            }
        }

    }




}
