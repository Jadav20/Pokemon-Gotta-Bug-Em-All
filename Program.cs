using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Pokemon> roster = new List<Pokemon>();

            //Movelist
            Move ember = new Move("Ember", 40, Elements.Fire);
            Move fireBlast = new Move("Fire Blast", 110, Elements.Fire);
            Move bubble = new Move("Bubble", 40, Elements.Water);
            Move bite = new Move("Bite", 60, Elements.Dark);
            Move cut = new Move("Cut", 50, Elements.Normal);
            Move megaDrain = new Move("Mega Drain", 40, Elements.Grass);
            Move razorLeaf = new Move("Razor Leaf", 55, Elements.Grass);
            Move slam = new Move("Slam", 80, Elements.Normal);
            Move hyperbeam = new Move("Hyper Beam", 150, Elements.Normal);
            Move psychic = new Move("Psychic", 90, Elements.Psychic);
            Move blizzard = new Move("Blizzard", 120, Elements.Ice);
            Move thunderbolt = new Move("Thunder Bolt", 95, Elements.Electric);
            Move lick = new Move("Lick", 20, Elements.Ghost);
            Move explosion = new Move("Explosion", 170, Elements.Normal);
            Move surf = new Move("Surf", 95, Elements.Water);
            Move fly = new Move("Fly", 70, Elements.Flying);
            Move earthquake = new Move("Earthquake", 100, Elements.Ground);
            Move hydropump = new Move("Hydro Pump", 120, Elements.Water);
            Move bodyslam = new Move("Body Slam", 85, Elements.Normal);
            Move solarbeam = new Move("Solar Beam", 120, Elements.Grass);

            // INITIALIZE YOUR THREE POKEMONS HERE
            List<Move> charMoves = new List<Move>();
            Pokemon charmander = new Pokemon("Charmander", 3, 52, 43, 39, Elements.Fire, charMoves);
            roster.Add(charmander);
            charMoves.Add(ember);
            charMoves.Add(fireBlast);


            List<Move> squirtMoves = new List<Move>();
            Pokemon squirtle = new Pokemon("Squirtle", 2, 48, 65, 44, Elements.Water, squirtMoves);
            roster.Add(squirtle);
            squirtMoves.Add(bubble);
            squirtMoves.Add(bite);

            List<Move> bulbMoves = new List<Move>();
            Pokemon bulbasaur = new Pokemon("Bulbasaur", 3, 49, 49, 45, Elements.Grass, bulbMoves);
            roster.Add(bulbasaur);
            bulbMoves.Add(cut);
            bulbMoves.Add(megaDrain);
            bulbMoves.Add(razorLeaf);

            List<Move> chariMoves = new List<Move>();
            Pokemon charizard = new Pokemon("Charizard", 50, 84, 78, 78, Elements.Fire, chariMoves);
            roster.Add(charizard);
            chariMoves.Add(fireBlast);
            chariMoves.Add(fly);
            chariMoves.Add(hyperbeam);
            chariMoves.Add(earthquake);

            List<Move> blasMoves = new List<Move>();
            Pokemon blastoise = new Pokemon("Blastoise", 50, 83, 100, 79, Elements.Water, blasMoves);
            roster.Add(blastoise);
            blasMoves.Add(surf);
            blasMoves.Add(blizzard);
            blasMoves.Add(earthquake);
            blasMoves.Add(hydropump);

            List<Move> venuMoves = new List<Move>();
            Pokemon venusaur = new Pokemon("Venusaur", 50, 82, 83, 80, Elements.Grass, venuMoves);
            roster.Add(venusaur);
            venuMoves.Add(razorLeaf);
            venuMoves.Add(hyperbeam);
            venuMoves.Add(solarbeam);
            venuMoves.Add(bodyslam);


            List<Move> pikaMoves = new List<Move>();
            Pokemon pikachu = new Pokemon("Pikachu", 50, 55, 30, 35, Elements.Electric, pikaMoves);
            roster.Add(pikachu);
            pikaMoves.Add(thunderbolt);
            pikaMoves.Add(slam);
            pikaMoves.Add(fly);
            pikaMoves.Add(surf);


            List<Move> gengMoves = new List<Move>();
            Pokemon gengar = new Pokemon("Gengar", 50, 65, 60, 60, Elements.Ghost, gengMoves);
            roster.Add(gengar);
            gengMoves.Add(psychic);
            gengMoves.Add(explosion);
            gengMoves.Add(thunderbolt);
            gengMoves.Add(lick);

            List<Move> mew2Moves = new List<Move>();
            Pokemon mewtwo = new Pokemon("Mewtwo", 99, 110, 90, 106, Elements.Psychic, mew2Moves);
            roster.Add(mewtwo);
            mew2Moves.Add(hyperbeam);
            mew2Moves.Add(psychic);
            mew2Moves.Add(blizzard);
            mew2Moves.Add(thunderbolt);


            

            Console.WriteLine("Welcome to Jacob Davis's world of Pokemon: Adventures in C#!");

            Console.WriteLine("\n" + @"                                  ,'\" +
                "\n" + @"    _.----.        ____         ,'  _\   ___    ___     ____" +
                "\n" + @"_,-'       `.     |    |  /`.   \,-'    |   \  /   |   |    \  |`." +
                "\n" + @"\      __    \    '-.  | /   `.  ___    |    \/    |   '-.   \ |  |" +
                "\n" + @" \.    \ \   |  __  |  |/    ,','_  `.  |          | __  |    \|  |" +
                "\n" + @"   \    \/   /,' _`.|      ,' / / / /   |          ,' _`.|     |  |" +
                "\n" + @"    \     ,-'/  /   \    ,'   | \/ / ,`.|         /  /   \  |     |" +
                "\n" + @"     \    \ |   \_/  |   `-.  \    `'  /|  |    ||   \_/  | |\    |" +
                "\n" + @"      \    \ \      /       `-.`.___,-' |  |\  /| \      /  | |   |" +
                "\n" + @"       \    \ `.__,'|  |`-._    `|      |__| \/ |  `.__,'|  | |   |" +
                "\n" + @"        \_.-'       |__|    `-._ |              '-.|     '-.| |   |" +
                "\n" + @"                                `'                            '-._|");


            while (true)
            {
                Console.WriteLine("\nPlease enter a command (list/fight/heal/quit)");
                switch (Console.ReadLine())
                {
                    case "list":
                        Console.Clear();
                        // PRINT THE POKEMONS IN THE ROSTER HERE
                        Console.WriteLine("The list of Pokemon available are:");

                        for (int i = 0; i < roster.Count; i++)
                        {
                            Console.WriteLine(roster[i].Name + "\n Level: " + roster[i].Level + "\n HP: " + roster[i].Hp);
                            Console.WriteLine();
                        }

                        break;

                    case "fight":
                        //PRINT INSTRUCTIONS AND POSSIBLE POKEMONS (SEE SLIDES FOR EXAMPLE OF EXECUTION)
                        Console.Clear();

                        for (int i = 0; i < roster.Count; i++)
                        {
                            Console.WriteLine(roster[i].Name + "\n Level: " + roster[i].Level + "\n HP: " + roster[i].Hp);
                            Console.WriteLine();
                        }

                        Console.WriteLine("Choose who should fight. You are not allowed to choose the same twice. Write as 'pokemon1 pokemon2'. \nDo go nuts with the lower and uppercases if you feel whimsical:");


                        //READ INPUT, REMEMBER IT SHOULD BE TWO POKEMON NAMES
                        string input = Console.ReadLine();

                        string[] inputs = input.Split(' ');



                        Pokemon player = null;
                        Pokemon enemy = null;

                        if (inputs.Length != 1)
                        {
                            for (int i = 0; i < roster.Count; i++)
                            {
                                if (String.Compare(inputs[0], roster[i].Name, true) == 0)
                                {
                                    player = roster[i];

                                }
                            }

                            for (int i = 0; i < roster.Count; i++)
                            {
                                if (String.Compare(inputs[1], roster[i].Name, true) == 0)
                                {
                                    enemy = roster[i];

                                }
                            }
                        }


                        

                        //BE SURE TO CHECK THE POKEMON NAMES THE USER WROTE ARE VALID (IN THE ROSTER) AND IF THEY ARE IN FACT 2!


                        //if everything is fine and we have 2 pokemons let's make them fight
                        if (player != null && enemy != null && player != enemy)
                        {
                            Console.Clear();
                            Console.WriteLine("A wild " + enemy.Name + " appears!");
                            Console.WriteLine(player.Name + " I choose you! ");

                            bool fightStart = true;

                            //BEGIN FIGHT LOOP
                            while (player.Hp > 0 && enemy.Hp > 0)
                            {
                                if (!fightStart)
                                {

                                }

                                //PRINT POSSIBLE MOVES
                                Console.WriteLine();
                                Console.WriteLine("Level " + player.Level + " " + player.Name + "'s HP is " + player.Hp + "\nLevel " + player.Level + " " + enemy.Name + "'s HP is " + enemy.Hp);
                                
                                int move = -1;

                                while (move == -1)
                                {
                                    Console.WriteLine("\nYour " + player.Name + " can do this:");
                                    for (int i = 0; i < player.Moves.Count; i++)
                                    {
                                        Console.WriteLine(" " + player.Moves[i].Name);
                                    }
                                    Console.WriteLine("\nWhat move should we use?:");

                                    input = Console.ReadLine();

                                    for (int i = 0; i < player.Moves.Count; i++)
                                    {
                                        if (String.Compare(input, player.Moves[i].Name, true) == 0)
                                        {
                                            move = i;
                                        }
                                    }


                                    if (move == -1)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Something you typed didn't work. Give it another try.");
                                    }

                                }


                                Console.Clear();


                                //GET USER ANSWER, BE SURE TO CHECK IF IT'S A VALID MOVE, OTHERWISE ASK AGAIN
                                int damage = player.Attack(enemy, player.Moves[move].Power, player.Moves[move].Type);
                                
                                //CALCULATE AND APPLY DAMAGE

                                //print the move and damage
                                Console.WriteLine(player.Name + " uses " + player.Moves[move].Name + ". " + enemy.Name + " loses " + damage + " HP");
                                player.IsEffective();
                                //Console.WriteLine(" " + enemy.Name + " loses " + damage + " HP");

                                //if the enemy is not dead yet, it attacks
                                if (enemy.Hp > 0)
                                {
                                    //CHOOSE A RANDOM MOVE BETWEEN THE ENEMY MOVES AND USE IT TO ATTACK THE PLAYER
                                    Random rand = new Random();
                                    /*the C# random is a bit different than the Unity random
                                     * you can ask for a number between [0,X) (X not included) by writing
                                     * rand.Next(X) 
                                     * where X is a number 
                                     */
                                    Move enemyAttack = enemy.Moves[rand.Next(enemy.Moves.Count)];


                                    int enemyDamage = enemy.Attack(player,enemyAttack.Power, enemyAttack.Type);

                                    //print the move and damage
                                    Console.WriteLine(enemy.Name + " uses " + enemyAttack.Name + ". " + player.Name + " loses " + enemyDamage + " HP");
                                    enemy.IsEffective();

                                }
                                fightStart = false;
                            }
                            //The loop is over, so either we won or lost
                            if (enemy.Hp <= 0)
                            {
                                Console.WriteLine(enemy.Name + " faints, you won!");
                            }
                            else
                            {
                                Console.WriteLine(player.Name + " faints, you lost...");
                            }
                        }
                        //otherwise let's print an error message
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid pokemons");
                        }
                        break;

                    case "heal":
                        //RESTORE ALL POKEMONS IN THE ROSTER
                        for (int i = 0; i < roster.Count; i++)
                        {
                            roster[i].Restore();
                        }
                        Console.Clear();
                        Console.WriteLine("All pokemons have been healed");
                        break;

                    case "quit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}
