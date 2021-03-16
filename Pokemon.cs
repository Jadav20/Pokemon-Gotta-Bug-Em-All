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
        Fire,
        Water,
        Grass
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
        public int Attack(Pokemon enemy, int Attack)
        {

            //The formula for calculating damage we were given was fundamentally flawed, so I implemented the real one from the games.
            //https://bulbapedia.bulbagarden.net/wiki/Damage

            int damage = (((2 * level) / 5) + 2) * (CalculateElementalEffects(Attack, enemy.element) * (CalculateAttack()/enemy.CalculateDefence())/50 + 2);

            //int damage = (CalculateElementalEffects(baseAttack, enemy.element) - enemy.CalculateDefence());

            if (damage < 1)
            {
                Console.WriteLine();
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
        public int CalculateElementalEffects(int damage, Elements enemyType)
        {
            
            if (element == Elements.Fire)
            {
                if (enemyType == Elements.Fire)
                {
                    return damage;
                }
                else if (enemyType == Elements.Water)
                {
                    return (damage/2);
                }
                else if (enemyType == Elements.Grass)
                {
                    return 2*damage;
                }
            }
            else if (element == Elements.Water)
            {
                if (enemyType == Elements.Fire)
                {
                    return 2*damage;
                }
                else if (enemyType == Elements.Water)
                {
                    return damage;
                }
                else if (enemyType == Elements.Grass)
                {
                    return (damage/2);
                }
            }
            else if (element == Elements.Grass)
            {
                if (enemyType == Elements.Fire)
                {
                    return (damage/2);
                }
                else if (enemyType == Elements.Water)
                {
                    return 2*damage;
                }
                else if (enemyType == Elements.Grass)
                {
                    return damage;
                }
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
    }
}
