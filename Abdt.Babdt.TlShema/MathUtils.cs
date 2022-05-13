using System;

namespace Abdt.Babdt.TlShema
{
    internal static class MathUtils
    {
        private const ulong Base = 4294967296;

        public static ulong[] Shift(ulong[] values, int shift)
        {
            if (shift == 0)
                return values;
            return shift >= 0 ? MathUtils.ShiftRight(values, shift) : MathUtils.ShiftLeft(values, -shift);
        }

        public static ulong[] ShiftRight(ulong[] values, int shift)
        {
            if (shift < 0)
                return MathUtils.ShiftLeft(values, -shift);
            int length = values.Length;
            shift %= length * 64;
            int num1 = shift / 64;
            int num2 = shift % 64;
            ulong[] numArray = new ulong[length];
            for (int index1 = 0; index1 < length; ++index1)
            {
                int index2 = index1 - num1;
                if (index2 >= 0)
                {
                    numArray[index2] |= values[index1] >> num2;
                    if (num2 > 0 && index1 + 1 < length)
                        numArray[index2] |= values[index1 + 1] << 64 - num2;
                }
            }
            return numArray;
        }

        public static ulong[] ShiftRightSigned(ulong[] values, int shift)
        {
            if (shift < 0)
                return MathUtils.ShiftLeft(values, -shift);
            int length = values.Length;
            for (shift %= length * 64; shift >= 64; shift -= 64)
            {
                for (int index = 0; index < length - 1; ++index)
                    values[index] = values[index + 1];
                values[length - 1] = values[length - 1] >> 63;
            }
            if (shift == 0)
                return values;
            int num = 64 - shift;
            ulong[] numArray = new ulong[length];
            numArray[length - 1] = values[length - 1] >> shift;
            for (int index = 0; index < length - 1; ++index)
            {
                numArray[index] = values[index] >> shift;
                numArray[index] |= values[index + 1] << num;
            }
            return numArray;
        }

        public static ulong[] ShiftLeft(ulong[] values, int shift)
        {
            if (shift < 0)
                return MathUtils.ShiftRight(values, -shift);
            int length = values.Length;
            shift %= length * 64;
            int num1 = shift / 64;
            int num2 = shift % 64;
            ulong[] numArray = new ulong[length];
            for (int index1 = 0; index1 < length; ++index1)
            {
                int index2 = index1 + num1;
                if (index2 < length)
                {
                    numArray[index2] |= values[index1] << num2;
                    if (num2 > 0 && index1 - 1 >= 0)
                        numArray[index2] |= values[index1 - 1] >> 64 - num2;
                }
            }
            return numArray;
        }

        public static void GetPrimeMultipliers(this Int128 pq, out Int128 p, out Int128 q)
        {
            Int256 p1;
            Int256 q1;
            ((Int256)pq).GetPrimeMultipliers(out p1, out q1);
            p = (Int128)p1;
            q = (Int128)q1;
        }

        public static void GetPrimeMultipliers(this Int256 pq, out Int256 p, out Int256 q)
        {
            p = MathUtils.PollardRho(pq);
            q = pq / p;
            if (!(p > q))
                return;
            Int256 int256 = p;
            p = q;
            q = int256;
        }

        public static Int256 PollardRho(Int256 number)
        {
            Func<Int256, Int256, Int256> func = (Func<Int256, Int256, Int256>)((param, mod) => (param * param + (Int256)1) % mod);
            Int256 int256_1 = (Int256)2;
            Int256 int256_2 = (Int256)2;
            Int256 int256_3;
            do
            {
                int256_1 = func(int256_1, number);
                int256_2 = func(func(int256_2, number), number);
                int256_3 = (int256_1 > int256_2 ? int256_1 - int256_2 : int256_2 - int256_1).GCD(number);
            }
            while (int256_3 <= (Int256)1);
            return int256_3;
        }

        public static Int128 GCD(this Int128 a, Int128 b)
        {
            Int128 int128_1;
            Int128 int128_2;
            for (; !(b == (Int128)0); b = int128_1 % int128_2)
            {
                int128_1 = a;
                a = b;
                int128_2 = b;
            }
            return a;
        }

        public static Int256 GCD(this Int256 a, Int256 b)
        {
            Int256 int256_1;
            Int256 int256_2;
            for (; !(b == (Int256)0); b = int256_1 % int256_2)
            {
                int256_1 = a;
                a = b;
                int256_2 = b;
            }
            return a;
        }

        private static int GetNormalizeShift(uint value)
        {
            int normalizeShift = 0;
            if (((int)value & -65536) == 0)
            {
                value <<= 16;
                normalizeShift += 16;
            }
            if (((int)value & -16777216) == 0)
            {
                value <<= 8;
                normalizeShift += 8;
            }
            if (((int)value & -268435456) == 0)
            {
                value <<= 4;
                normalizeShift += 4;
            }
            if (((int)value & -1073741824) == 0)
            {
                value <<= 2;
                normalizeShift += 2;
            }
            if (((int)value & int.MinValue) == 0)
            {
                value <<= 1;
                ++normalizeShift;
            }
            return normalizeShift;
        }

        private static void Normalize(uint[] u, int l, uint[] un, int shift)
        {
            uint num1 = 0;
            int index;
            if (shift > 0)
            {
                int num2 = 32 - shift;
                for (index = 0; index < l; ++index)
                {
                    uint num3 = u[index];
                    un[index] = num3 << shift | num1;
                    num1 = num3 >> num2;
                }
            }
            else
            {
                for (index = 0; index < l; ++index)
                    un[index] = u[index];
            }
            while (index < un.Length)
                un[index++] = 0U;
            if (num1 == 0U)
                return;
            un[l] = num1;
        }

        private static void Unnormalize(uint[] un, out uint[] r, int shift)
        {
            int length = un.Length;
            r = new uint[length];
            if (shift > 0)
            {
                int num1 = 32 - shift;
                uint num2 = 0;
                for (int index = length - 1; index >= 0; --index)
                {
                    uint num3 = un[index];
                    r[index] = num3 >> shift | num2;
                    num2 = num3 << num1;
                }
            }
            else
            {
                for (int index = 0; index < length; ++index)
                    r[index] = un[index];
            }
        }

        private static int GetLength(uint[] uints)
        {
            int index = uints.Length - 1;
            while (index >= 0 && uints[index] == 0U)
                --index;
            return (index < 0 ? 0 : index) + 1;
        }

        private static uint[] TrimZeros(uint[] uints)
        {
            uint[] dst = new uint[MathUtils.GetLength(uints)];
            Buffer.BlockCopy((Array)uints, 0, (Array)dst, 0, dst.Length * 4);
            return dst;
        }

        public static void DivModUnsigned(uint[] u, uint[] v, out uint[] q, out uint[] r)
        {
            int length1 = MathUtils.GetLength(u);
            int length2 = MathUtils.GetLength(v);
            if (length2 <= 1)
            {
                ulong num1 = 0;
                uint num2 = v[0];
                q = new uint[length1];
                r = new uint[1];
                for (int index = length1 - 1; index >= 0; --index)
                {
                    ulong num3 = num1 * 4294967296UL + (ulong)u[index];
                    ulong num4 = num3 / (ulong)num2;
                    num1 = num3 - num4 * (ulong)num2;
                    q[index] = (uint)num4;
                }
                r[0] = (uint)num1;
            }
            else if (length1 >= length2)
            {
                int normalizeShift = MathUtils.GetNormalizeShift(v[length2 - 1]);
                uint[] un1 = new uint[length1 + 1];
                uint[] un2 = new uint[length2];
                MathUtils.Normalize(u, length1, un1, normalizeShift);
                MathUtils.Normalize(v, length2, un2, normalizeShift);
                q = new uint[length1 - length2 + 1];
                r = (uint[])null;
                for (int index1 = length1 - length2; index1 >= 0; --index1)
                {
                    ulong num5 = 4294967296UL * (ulong)un1[index1 + length2] + (ulong)un1[index1 + length2 - 1];
                    ulong num6 = num5 / (ulong)un2[length2 - 1];
                    ulong num7 = num5 - num6 * (ulong)un2[length2 - 1];
                    while (num6 >= 4294967296UL || num6 * (ulong)un2[length2 - 2] > num7 * 4294967296UL + (ulong)un1[index1 + length2 - 2])
                    {
                        --num6;
                        num7 += (ulong)un2[length2 - 1];
                        if (num7 >= 4294967296UL)
                            break;
                    }
                    long num8 = 0;
                    for (int index2 = 0; index2 < length2; ++index2)
                    {
                        ulong num9 = (ulong)un2[index2] * num6;
                        long num10 = (long)un1[index2 + index1] - (long)(uint)num9 - num8;
                        un1[index2 + index1] = (uint)num10;
                        num8 = (long)(num9 >> 32) - (num10 >> 32);
                    }
                    long num11 = (long)un1[index1 + length2] - num8;
                    un1[index1 + length2] = (uint)num11;
                    q[index1] = (uint)num6;
                    if (num11 < 0L)
                    {
                        --q[index1];
                        ulong num12 = 0;
                        for (int index3 = 0; index3 < length2; ++index3)
                        {
                            ulong num13 = (ulong)un2[index3] + (ulong)un1[index1 + index3] + num12;
                            un1[index1 + index3] = (uint)num13;
                            num12 = num13 >> 32;
                        }
                        ulong num14 = num12 + (ulong)un1[index1 + length2];
                        un1[index1 + length2] = (uint)num14;
                    }
                }
                MathUtils.Unnormalize(un1, out r, normalizeShift);
            }
            else
            {
                q = new uint[1];
                r = u;
            }
            q = MathUtils.TrimZeros(q);
            r = MathUtils.TrimZeros(r);
        }
    }
}
