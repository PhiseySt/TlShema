using System;
using System.Collections.Generic;
using System.Linq;

namespace Abdt.Babdt.TlShema
{
    internal static class ArrayUtils
    {
        private static readonly byte[] CharToByteLookupTable = new byte[256]
        {
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            (byte)0,
            (byte)1,
            (byte)2,
            (byte)3,
            (byte)4,
            (byte)5,
            (byte)6,
            (byte)7,
            (byte)8,
            (byte)9,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            (byte)10,
            (byte)11,
            (byte)12,
            (byte)13,
            (byte)14,
            (byte)15,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            (byte)10,
            (byte)11,
            (byte)12,
            (byte)13,
            (byte)14,
            (byte)15,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue
        };

        private static readonly char[][] LookupTableUpper;
        private static readonly char[][] LookupTableLower = new char[256][];

        static ArrayUtils()
        {
            ArrayUtils.LookupTableUpper = new char[256][];
            for (int index = 0; index < 256; ++index)
            {
                ArrayUtils.LookupTableLower[index] = index.ToString("x2").ToCharArray();
                ArrayUtils.LookupTableUpper[index] = index.ToString("X2").ToCharArray();
            }
        }

        public static TOutput[] ConvertAll<TInput, TOutput>(
            this TInput[] array,
            Func<TInput, TOutput> convert)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (convert == null)
                throw new ArgumentNullException(nameof(convert));
            TOutput[] outputArray = new TOutput[array.Length];
            for (int index = 0; index < array.Length; ++index)
                outputArray[index] = convert(array[index]);
            return outputArray;
        }

        public static int GetNonZeroLength(this byte[] bytes, bool? asLittleEndian = null)
        {
            if (ArrayUtils.GetIsLittleEndian(asLittleEndian))
            {
                int index = bytes.Length - 1;
                while (index >= 0 && bytes[index] == (byte)0)
                    --index;
                return (index < 0 ? 0 : index) + 1;
            }

            int index1 = 0;
            while (index1 < bytes.Length && bytes[index1] == (byte)0)
                ++index1;
            int num = index1 >= bytes.Length ? bytes.Length - 1 : index1;
            return bytes.Length - num;
        }

        public static byte[] TrimZeros(this byte[] bytes, bool? asLittleEndian = null)
        {
            bool isLittleEndian = ArrayUtils.GetIsLittleEndian(asLittleEndian);
            int nonZeroLength = bytes.GetNonZeroLength(new bool?(isLittleEndian));
            byte[] dst = new byte[nonZeroLength];
            Buffer.BlockCopy((Array)bytes, isLittleEndian ? 0 : bytes.Length - nonZeroLength, (Array)dst, 0,
                nonZeroLength);
            return dst;
        }

        public static byte[] Combine(byte[] first, byte[] second)
        {
            byte[] dst = new byte[first.Length + second.Length];
            Buffer.BlockCopy((Array)first, 0, (Array)dst, 0, first.Length);
            Buffer.BlockCopy((Array)second, 0, (Array)dst, first.Length, second.Length);
            return dst;
        }

        public static byte[] Combine(byte[] first, byte[] second, byte[] third)
        {
            byte[] dst = new byte[first.Length + second.Length + third.Length];
            Buffer.BlockCopy((Array)first, 0, (Array)dst, 0, first.Length);
            Buffer.BlockCopy((Array)second, 0, (Array)dst, first.Length, second.Length);
            Buffer.BlockCopy((Array)third, 0, (Array)dst, first.Length + second.Length, third.Length);
            return dst;
        }

        public static byte[] Combine(params byte[][] arrays)
        {
            byte[] dst = new byte[((IEnumerable<byte[]>)arrays).Sum<byte[]>((Func<byte[], int>)(x => x.Length))];
            int dstOffset = 0;
            foreach (byte[] array in arrays)
            {
                Buffer.BlockCopy((Array)array, 0, (Array)dst, dstOffset, array.Length);
                dstOffset += array.Length;
            }

            return dst;
        }

        public static void Split<T>(this T[] array, int index, out T[] first, out T[] second)
        {
            first = ((IEnumerable<T>)array).Take<T>(index).ToArray<T>();
            second = ((IEnumerable<T>)array).Skip<T>(index).ToArray<T>();
        }

        public static void SplitMidPoint<T>(this T[] array, out T[] first, out T[] second) =>
            array.Split<T>(array.Length / 2, out first, out second);

        public static byte[] RewriteWithValue(this byte[] bytes, byte value, int offset, int length)
        {
            if (offset + length > bytes.Length)
                throw new InvalidOperationException("Offset + length must be less of equal of the bytes length.");
            byte[] numArray = (byte[])bytes.Clone();
            for (int index = offset; index < offset + length; ++index)
                numArray[index] = value;
            return numArray;
        }

        public static string ToHexString(
            this byte[] bytes,
            bool caps = true,
            int min = 0,
            bool spaceEveryByte = false,
            bool trimZeros = false)
        {
            return new ArraySegment<byte>(bytes, 0, bytes.Length).ToHexString(caps, min, spaceEveryByte, trimZeros);
        }

        public static string ToHexString(
            this ArraySegment<byte> bytes,
            bool caps = true,
            int min = 0,
            bool spaceEveryByte = false,
            bool trimZeros = false)
        {
            int count = bytes.Count;
            if (count == 0)
                return string.Empty;
            int length = min;
            int num1 = 0;
            if (trimZeros)
            {
                num1 = count - 1;
                for (int index = 0; index < count; ++index)
                {
                    if (bytes.Array[index + bytes.Offset] > (byte)0)
                    {
                        num1 = index;
                        int num2 = (count - index) * 2;
                        length = num2 <= min ? min : num2;
                        break;
                    }
                }
            }
            else
            {
                int num3 = count * 2;
                length = num3 < min ? min : num3;
            }

            if (length == 0)
                return "0";
            int num4 = 0;
            if (spaceEveryByte)
            {
                length += length / 2 - 1;
                num4 = 1;
            }

            char[] chArray1 = new char[length];
            for (int index = 0; index < chArray1.Length; ++index)
                chArray1[index] = '0';
            if (spaceEveryByte)
            {
                for (int index = 2; index < chArray1.Length; index += 3)
                    chArray1[index] = ' ';
            }

            char[][] chArray2 = caps ? ArrayUtils.LookupTableUpper : ArrayUtils.LookupTableLower;
            int num5 = count - 1;
            int num6 = length - 1;
            while (num5 >= num1)
            {
                char[] chArray3 = chArray2[(int)bytes.Array[bytes.Offset + num5--]];
                char[] chArray4 = chArray1;
                int index1 = num6;
                int num7 = index1 - 1;
                int num8 = (int)chArray3[1];
                chArray4[index1] = (char)num8;
                char[] chArray5 = chArray1;
                int index2 = num7;
                int num9 = index2 - 1;
                int num10 = (int)chArray3[0];
                chArray5[index2] = (char)num10;
                num6 = num9 - num4;
            }

            int startIndex = 0;
            if (trimZeros && length > min)
            {
                for (int index = 0; index < chArray1.Length; ++index)
                {
                    switch (chArray1[index])
                    {
                        case ' ':
                        case '0':
                            continue;
                        default:
                            startIndex = index;
                            goto label_29;
                    }
                }
            }

        label_29:
            return new string(chArray1, startIndex, length - startIndex);
        }

        public static byte[] HexToBytes(this string hexString)
        {
            byte[] bytes;
            if (string.IsNullOrWhiteSpace(hexString))
            {
                bytes = new byte[0];
            }
            else
            {
                int length = hexString.Length;
                int index1 = hexString.StartsWith("0x", StringComparison.Ordinal) ? 2 : 0;
                int num1 = index1;
                int num2 = length - num1;
                bool flag = false;
                if (num2 % 2 != 0)
                {
                    flag = true;
                    ++num2;
                }

                bytes = new byte[num2 / 2];
                int num3 = 0;
                if (flag)
                {
                    bytes[num3++] = ArrayUtils.CharToByteLookupTable[(int)hexString[index1]];
                    ++index1;
                }

                while (index1 < hexString.Length)
                {
                    byte[] toByteLookupTable1 = ArrayUtils.CharToByteLookupTable;
                    string str1 = hexString;
                    int index2 = index1;
                    int num4 = index2 + 1;
                    int index3 = (int)str1[index2];
                    int num5 = (int)toByteLookupTable1[index3];
                    byte[] toByteLookupTable2 = ArrayUtils.CharToByteLookupTable;
                    string str2 = hexString;
                    int index4 = num4;
                    index1 = index4 + 1;
                    int index5 = (int)str2[index4];
                    int num6 = (int)toByteLookupTable2[index5];
                    bytes[num3++] = (byte)(num5 << 4 | num6);
                }
            }

            return bytes;
        }

        private static bool GetIsLittleEndian(bool? asLittleEndian) =>
            !asLittleEndian.HasValue ? BitConverter.IsLittleEndian : asLittleEndian.Value;
    }
}