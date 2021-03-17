using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    /// <summary>
    /// The possible elemental types
    /// </summary>
    public enum Elements
    {
        Normal,
        Fight,
        Flying,
        Poison,
        Ground,
        Rock,
        Bug,
        Ghost,
        Steel,
        Fire,
        Water,
        Grass,
        Electric,
        Psychic,
        Ice,
        Dragon,
        Dark,
        Fairy
    }

    

    public class Pokemon
    {
        //fields
        int level;
        int baseAttack;
        int baseDefence;
        int hp;
        int maxHp;
        Elements element;

        public int modifier;

        //properties, imagine them as private fields with a possible get/set property (accessors)
        //in this case used to allow other objects to read (get) but not write (no set) these variables
        public string Name { get; }
        //example of how to make the string Name readable AND writable  
        //  public string Name { get; set; }
        public List<Move> Moves { get; }
        //can also be used to get/set other private fields
        public int Hp { get => hp; }

        public int Level { get => level; }
        public int MaxHp { get => maxHp; }

        public int hpBase { get; }


        /// <summary>
        /// Constructor for a Pokemon, the arguments are fairly self-explanatory
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        /// <param name="baseAttack"></param>
        /// <param name="baseDefence"></param>
        /// <param name="hp"></param>
        /// <param name="element"></param>
        /// <param name="moves">This needs to be a List of Move objects</param>
        public Pokemon(string name, int level, int baseAttack,
            int baseDefence, int hpBase, Elements element,
            List<Move> moves)
        {
            this.level = level;
            this.baseAttack = baseAttack;
            this.baseDefence = baseDefence;
            this.Name = name;
            this.hpBase = hpBase;
            //total HP is calculated from the Generation III formula 
            // https://bulbapedia.bulbagarden.net/wiki/Stat#Formula
            this.hp = ((2*hpBase * level)/100 + level + 10);
            this.maxHp = hp;
            this.element = element;
            this.Moves = moves;
        }

        /// <summary>
        /// performs an attack and returns total damage, check the slides for how to calculate the damage
        /// IMPORTANT: should also apply the damage to the enemy pokemon
        /// </summary>
        /// <param name="enemy">This is the enemy pokemon that we are attacking</param>
        /// <returns>The amount of damage that was applied so we can print it for the user</returns>
        public int Attack(Pokemon enemy, int Attack, Elements moveType)
        {

            //The formula for calculating damage we were given was fundamentally flawed, so I implemented the real one from the games.
            //https://bulbapedia.bulbagarden.net/wiki/Damage

            int damage = (((2 * level) / 5) + 2) * (CalculateElementalEffects(Attack, enemy.element, moveType) * (CalculateAttack()/enemy.CalculateDefence())/50 + 2);

            //int damage = (CalculateElementalEffects(baseAttack, enemy.element) - enemy.CalculateDefence());


            //STAB (Same-type attack bonus) gets applied here
            //https://bulbapedia.bulbagarden.net/wiki/Same-type_attack_bonus
            if (element == moveType)
            {
                damage = damage + (damage*2)/4;
                Console.WriteLine("STAB is applied");
            }

            enemy.hp -= damage;
            return damage;
        }

        /// <summary>
        /// calculate the current amount of defence points
        /// </summary>
        /// <returns> returns the amount of defence points considering the level as well</returns>
        /// 
        /*

        public int CalculateDefence()
        {
            int totDefense = baseDefence * level;

            return totDefense;
        }
        */


        /// <summary>
        /// Calculates elemental effect, check table at https://bulbapedia.bulbagarden.net/wiki/Type#Type_chart for a reference
        /// </summary>
        /// <param name="damage">The amount of pre elemental-effect damage</param>
        /// <param name="enemyType">The elemental type of the enemy</param>
        /// <returns>The damage post elemental-effect</returns>
        public int CalculateElementalEffects(int damage, Elements enemyType, Elements moveType)
        {

            modifier = 1;

            Dictionary<Elements, int> attackEffective = new Dictionary<Elements, int>();
            attackEffective.Add(Elements.Normal, 0);
            attackEffective.Add(Elements.Fight, 1);
            attackEffective.Add(Elements.Flying, 2);
            attackEffective.Add(Elements.Poison, 3);
            attackEffective.Add(Elements.Ground, 4);
            attackEffective.Add(Elements.Rock, 5);
            attackEffective.Add(Elements.Bug, 6);
            attackEffective.Add(Elements.Ghost, 7);
            attackEffective.Add(Elements.Steel, 8);
            attackEffective.Add(Elements.Fire, 9);
            attackEffective.Add(Elements.Water, 10);
            attackEffective.Add(Elements.Grass, 11);
            attackEffective.Add(Elements.Electric, 9);
            attackEffective.Add(Elements.Psychic, 10);
            attackEffective.Add(Elements.Ice, 11);
            attackEffective.Add(Elements.Dragon, 12);
            attackEffective.Add(Elements.Dark, 13);
            attackEffective.Add(Elements.Fairy, 14);


            int[,] elementalTable =
            {
                { 1, 1, 1, 1, 1, 0, 1, -1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 },  //Normal
                { 2, 1, 0, 0, 1, 2, 0, -1, 2, 1, 1, 1, 1, 0, 2, 1, 2, 0 },  //Fight
                { 1, 2, 1, 1, 1, 0, 2, 1, 0, 1, 1, 2, 0, 1, 1, 1, 1, 1 },   //Flying
                { 1, 1, 1, 0, 0, 0, 1, 0, -1, 1, 1, 2, 1, 1, 1, 1, 1, 2 },  //Poison
                { 1, 1, -1, 2, 1, 2, 0, 1, 2, 2, 1, 0, 2, 1, 1, 1, 1, 1 },  //Ground
                { 1, 0, 2, 1, 0, 1, 2, 1, 0, 2, 1, 1, 1, 1, 2, 1, 1, 1 },   //Rock
                { 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 2, 1, 2, 1, 1, 2, 0 },   //Bug
                { -1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 0, 1 },  //Ghost
                { 1, 1, 1, 1, 1, 2, 1, 1, 0, 0, 0, 1, 0, 1, 2, 1, 1, 2 },   //Steel
                { 1, 1, 1, 1, 1, 0, 2, 1, 2, 0, 0, 2, 1, 1, 2, 0, 1, 1 },   //Fire
                { 1, 1, 1, 1, 2, 2, 1, 1, 1, 2, 0, 0, 1, 1, 1, 0, 1, 1 },   //Water
                { 1, 1, 0, 0, 2, 2, 0, 1, 0, 0, 2, 0, 1, 1, 1, 0, 1, 1 },   //Grass
                { 1, 1, 2, 1, -1, 1, 1, 1, 1, 1, 2, 0, 0, 1, 1, 0, 1, 1 },  //Electric
                { 1, 2, 1, 2, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, -1, 1 },  //Psychic
                { 1, 1, 2, 1, 2, 1, 1, 1, 0, 0, 0, 2, 1, 1, 0, 2, 1, 1 },   //Ice
                { 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 2, 1, -1 },  //Dragon
                { 1, 0, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 0, 0 },   //Dark
                { 1, 2, 1, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 2, 2, 1 }    //Fairy
            };


            modifier = elementalTable[attackEffective[moveType],attackEffective[enemyType]];

            Console.WriteLine("Attack: " + moveType + " Defense: " + enemyType);
            Console.WriteLine("Attack: " + attackEffective[moveType] + " Defense: " + attackEffective[enemyType]);
            Console.WriteLine("Modifier: " + modifier);

            if (modifier == 1)
            {
                return damage;
            }
            else if (modifier == 0)
            {
                return (damage / 2);
            }
            else if (modifier == 2)
            {
                return 2 * damage;
            }
            else if (modifier == -1)
            {
                return damage * 0;
            }

            return damage;
        }

        /*
        /// <summary>
        /// Applies damage to the pokemon
        /// </summary>
        /// <param name="damage"></param>
        public void ApplyDamage(int damage)
        {
            throw new NotImplementedException();
        }
        */

        //The total Attack and Defense values are calculated on the basis that with every level, 1/50 of the base stat is added.
        //Taken from this information https://bulbapedia.bulbagarden.net/wiki/Stat#Level

        public int CalculateAttack()
        {
            int totAttack = baseAttack + (baseAttack * (1 / 50) * level);

            return totAttack;
        }

        public int CalculateDefence()
        {
            int totDefense = baseDefence + (baseDefence * (1 / 50) * level);

            return totDefense;
        }

        /// <summary>
        /// Heals the pokemon by resetting the HP to the max
        /// </summary>
        public void Restore()
        {
            hp = maxHp;
        }
        public void IsEffective()
        {
            if (modifier == 2)
            {
                Console.WriteLine("It's super effective!");
            }
            else if (modifier == 0)
            {
                Console.WriteLine("It's not very effective.");
            }
        }
    }
}
