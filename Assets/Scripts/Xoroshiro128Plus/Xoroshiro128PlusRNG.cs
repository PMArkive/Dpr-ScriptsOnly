using System;

// Sourced from: https://gist.github.com/notflan/a4c5b9881f232a48813b50d67f9e34e6

/*  Written in 2016-2018 by David Blackman and Sebastiano Vigna (vigna@acm.org)
 * To the extent possible under law, the author has dedicated all copyright
 * and related and neighboring rights to this software to the public domain
 * worldwide. This software is distributed without any warranty.
 
 * See <http://creativecommons.org/publicdomain/zero/1.0/>. */

/**
 * Blackman and Vigna's XOr ROtate SHIft ROtate 128+ PRNG algorithm <http://vigna.di.unimi.it/xorshift/xoroshiro128plus.c> implementation in C#.
 * A lot of the code was taken from SquidLib's Java implementation <https://github.com/SquidPony/SquidLib/blob/master/squidlib-util/src/main/java/squidpony/squidmath/XoRoRNG.java>.
 * 
 * Uses Vigna's splitmix64 <https://github.com/svaarala/duktape/blob/master/misc/splitmix64.c> to generate 128 bit seed from 64 bit input. 
 **/

namespace Xoroshiro128Plus
{
    /// <summary>
    /// Xoroshiro128+ represented as instance of System.Random
    /// </summary>
    public class Xoroshiro128PlusRNG : Random
    {
        private Xoroshiro128Plus xoroshiro;

        public Xoroshiro128Plus Internal => xoroshiro;

        public override int Next()
        {
            return base.Next();
        }

        /// <summary>
        /// Seed Xoroshiro128+ with 64 bit integer using splitmix64.
        /// </summary>
        public Xoroshiro128PlusRNG(ulong seed)
        {
            xoroshiro = new Xoroshiro128Plus(seed);
        }

        /// <summary>
        /// Seed Xoroshiro128+ with 128 bits from System.Random
        /// </summary>
        /// <param name="r"></param>
        public Xoroshiro128PlusRNG(Random r)
        {
            xoroshiro = new Xoroshiro128Plus(r);
        }

        /// <summary>
        /// Seed Xoroshiro128+ with system time.
        /// </summary>
        public Xoroshiro128PlusRNG()
        {
            xoroshiro = new Xoroshiro128Plus();
        }

        /// <summary>
        /// Seed Xoroshiro128+ with 128 bit seed.
        /// </summary>
        /// <param name="state0">First 64 bits</param>
        /// <param name="state1">Second 64 bits</param>
        public Xoroshiro128PlusRNG(ulong state0, ulong state1)
        {
            xoroshiro = new Xoroshiro128Plus(state0, state1);
        }

        /// <summary>
        /// Seed Xoroshiro128+ with 128 bit seed from decimal.
        /// </summary>
        /// <param name="bits">Seed bits</param>
        public Xoroshiro128PlusRNG(decimal bits)
        {
            xoroshiro = new Xoroshiro128Plus(bits);
        }

        /// <summary>
        /// Seed Xoroshiro128+ with 128 bit seed. If there are less than 128 bits in the source array, it will be padded. Any extra will be ignored.
        /// </summary>
        /// <param name="bits">Bits for seed.</param>
        /// <param name="startindex">Start index of the array.</param>
        public Xoroshiro128PlusRNG(byte[] bits, int startindex)
        {
            if (startindex >= bits.Length)
                throw new ArgumentOutOfRangeException(nameof(bits));
            byte[] nw = new byte[bits.Length - startindex];

            Array.Copy(bits, startindex, nw, 0, nw.Length);
            if (nw.Length < 16)
            {
                var ob = nw;
                bits = new byte[16];
                Array.Copy(ob, bits, bits.Length);
            }
            else bits = nw;

            var s0 = BitConverter.ToUInt64(bits, 0);
            var s1 = BitConverter.ToUInt64(bits, sizeof(ulong));

            xoroshiro = new Xoroshiro128Plus(s0, s1);
        }

        /// <summary>
        /// Seed Xoroshiro128+ with 128 bit seed. If there are less than 128 bits in the source array, it will be padded. Any extra will be ignored.
        /// </summary>
        /// <param name="bits">Bits for seed.</param>
        public Xoroshiro128PlusRNG(byte[] bits)
        {
            if (bits.Length < 16)
            {
                var ob = bits;
                bits = new byte[16];
                Array.Copy(ob, bits, bits.Length);
            }
            var s0 = BitConverter.ToUInt64(bits, 0);
            var s1 = BitConverter.ToUInt64(bits, sizeof(ulong));

            xoroshiro = new Xoroshiro128Plus(s0, s1);
        }

        /// <summary>
        /// Seed Xoroshiro128+ from other Xoroshiro128Plus instance
        /// </summary>
        public Xoroshiro128PlusRNG(Xoroshiro128Plus other)
        {
            xoroshiro = new Xoroshiro128Plus(other);
        }

        /// <summary>
        /// Seed Xoroshiro128+ from other Xoroshiro128PlusRNG instance
        /// </summary>
        public Xoroshiro128PlusRNG(Xoroshiro128PlusRNG other)
        {
            xoroshiro = new Xoroshiro128Plus(other.xoroshiro);
        }

        float fracture(float f)
        {
            return (float)(Sample() * f);
        }

        public override int Next(int maxValue)
        {
            return (int)Math.Floor(fracture(maxValue));
        }

        public override int Next(int minValue, int maxValue)
        {
            return (int)Math.Floor(fracture(maxValue - minValue) + minValue);
        }

        public override void NextBytes(byte[] buffer)
        {
            xoroshiro.NextBytes(buffer);
        }

        public override double NextDouble()
        {
            return xoroshiro.NextDouble();
        }

        protected override double Sample()
        {
            return NextDouble();
        }
    }
}
