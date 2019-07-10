using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollerApp
{
    /// <summary>
    /// Represents a singular multi-sided die.
    /// </summary>
    class Die
    {
        private byte faceValue;
        private readonly byte numberOfSides;
        private static Random rand;

        static Die()
        {
            // Share one instance of Random across all
            // Instances of the Die Class
            rand = new Random();
        }

        /// <summary>
        /// Defaults numberOfSides to 6.
        /// </summary>
        public Die() : this(6){}

        /// <summary>
        /// Overloading Constructor for creating a die with the specified number of sides.
        /// </summary>
        /// <param name="numberOfSides">The number of sides on the die</param>
        public Die(byte numberOfSides)
        {
            this.numberOfSides = numberOfSides;
            Roll();
        }

        public byte FaceValue
        {
            get {return faceValue;}
            private set
            {
                if (value == 0)
                {
                    throw new Exception("Die cannot be 0");
                }
                faceValue = value;
            }
        }

        public bool IsHeld { get; set; }

        /// <summary>
        /// Rolls the die, sets face value to generated number
        /// and returns generated number.
        /// </summary>
        public byte Roll()
        {

            if (IsHeld)
            {
                return FaceValue;
            }
            const byte MinValue = 1;
            // Offset because of exclusive upper bound for random.
            byte MaxValue = (byte)(numberOfSides + 1);
            byte result = (byte)rand.Next(MinValue, MaxValue);
            FaceValue = result;

            return result;

        }
    }
}
