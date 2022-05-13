using System;
using System.Runtime.CompilerServices;

namespace Abdt.Babdt.TlShema
{
    internal static class ExtendedBitConverter
    {
        public static readonly bool IsLittleEndian = BitConverter.IsLittleEndian;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this short value, bool? asLittleEndian = null)
        {
            byte[] buffer = new byte[2];
            value.ToBytes(buffer, 0, asLittleEndian);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBytes(this short value, byte[] buffer, int offset = 0, bool? asLittleEndian = null)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if ((asLittleEndian.HasValue ? (asLittleEndian.Value ? 1 : 0) : (ExtendedBitConverter.IsLittleEndian ? 1 : 0)) != 0)
            {
                buffer[offset] = (byte)value;
                buffer[offset + 1] = (byte)((uint)value >> 8);
            }
            else
            {
                buffer[offset] = (byte)((uint)value >> 8);
                buffer[offset + 1] = (byte)value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToInt16(this byte[] bytes, int offset = 0, bool? asLittleEndian = null)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
            if (bytes.Length == 0)
                return 0;
            if (bytes.Length <= offset)
                throw new InvalidOperationException("Array length must be greater than offset.");
            bool isLittleEndian = ExtendedBitConverter.GetIsLittleEndian(asLittleEndian);
            ExtendedBitConverter.EnsureLength(ref bytes, 2, offset, isLittleEndian);
            return isLittleEndian ? (short)((int)bytes[offset] | (int)bytes[offset + 1] << 8) : (short)((int)bytes[offset] << 8 | (int)bytes[offset + 1]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this ushort value, bool? asLittleEndian = null) => ((short)value).ToBytes(asLittleEndian);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBytes(this ushort value, byte[] buffer, int offset = 0, bool? asLittleEndian = null) => ((short)value).ToBytes(buffer, offset, asLittleEndian);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ToUInt16(this byte[] bytes, int offset = 0, bool? asLittleEndian = null) => (ushort)bytes.ToInt16(offset, asLittleEndian);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this int value, bool? asLittleEndian = null)
        {
            byte[] buffer = new byte[4];
            value.ToBytes(buffer, 0, asLittleEndian);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBytes(this int value, byte[] buffer, int offset = 0, bool? asLittleEndian = null)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if ((asLittleEndian.HasValue ? (asLittleEndian.Value ? 1 : 0) : (ExtendedBitConverter.IsLittleEndian ? 1 : 0)) != 0)
            {
                buffer[offset] = (byte)value;
                buffer[offset + 1] = (byte)(value >> 8);
                buffer[offset + 2] = (byte)(value >> 16);
                buffer[offset + 3] = (byte)(value >> 24);
            }
            else
            {
                buffer[offset] = (byte)(value >> 24);
                buffer[offset + 1] = (byte)(value >> 16);
                buffer[offset + 2] = (byte)(value >> 8);
                buffer[offset + 3] = (byte)value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt32(this byte[] bytes, int offset = 0, bool? asLittleEndian = null)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
            if (bytes.Length == 0)
                return 0;
            if (bytes.Length <= offset)
                throw new InvalidOperationException("Array length must be greater than offset.");
            bool isLittleEndian = ExtendedBitConverter.GetIsLittleEndian(asLittleEndian);
            ExtendedBitConverter.EnsureLength(ref bytes, 4, offset, isLittleEndian);
            return !isLittleEndian ? (int)bytes[offset] << 24 | (int)bytes[offset + 1] << 16 | (int)bytes[offset + 2] << 8 | (int)bytes[offset + 3] : (int)bytes[offset] | (int)bytes[offset + 1] << 8 | (int)bytes[offset + 2] << 16 | (int)bytes[offset + 3] << 24;
        }

        private static void EnsureLength(ref byte[] bytes, int minLength, int offset, bool ale)
        {
            int count = bytes.Length - offset;
            if (count >= minLength)
                return;
            byte[] dst = new byte[minLength];
            Buffer.BlockCopy((Array)bytes, offset, (Array)dst, ale ? 0 : minLength - count, count);
            bytes = dst;
        }

        private static bool GetIsLittleEndian(bool? asLittleEndian) => !asLittleEndian.HasValue ? ExtendedBitConverter.IsLittleEndian : asLittleEndian.Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this uint value, bool? asLittleEndian = null) => ((int)value).ToBytes(asLittleEndian);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBytes(this uint value, byte[] buffer, int offset = 0, bool? asLittleEndian = null) => ((int)value).ToBytes(buffer, offset, asLittleEndian);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ToUInt32(this byte[] bytes, int offset = 0, bool? asLittleEndian = null) => (uint)bytes.ToInt32(offset, asLittleEndian);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this long value, bool? asLittleEndian = null)
        {
            byte[] buffer = new byte[8];
            value.ToBytes(buffer, asLittleEndian: asLittleEndian);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBytes(this long value, byte[] buffer, int offset = 0, bool? asLittleEndian = null)
        {
            if ((asLittleEndian.HasValue ? (asLittleEndian.Value ? 1 : 0) : (ExtendedBitConverter.IsLittleEndian ? 1 : 0)) != 0)
            {
                buffer[offset] = (byte)value;
                buffer[offset + 1] = (byte)(value >> 8);
                buffer[offset + 2] = (byte)(value >> 16);
                buffer[offset + 3] = (byte)(value >> 24);
                buffer[offset + 4] = (byte)(value >> 32);
                buffer[offset + 5] = (byte)(value >> 40);
                buffer[offset + 6] = (byte)(value >> 48);
                buffer[offset + 7] = (byte)(value >> 56);
            }
            else
            {
                buffer[offset] = (byte)(value >> 56);
                buffer[offset + 1] = (byte)(value >> 48);
                buffer[offset + 2] = (byte)(value >> 40);
                buffer[offset + 3] = (byte)(value >> 32);
                buffer[offset + 4] = (byte)(value >> 24);
                buffer[offset + 5] = (byte)(value >> 16);
                buffer[offset + 6] = (byte)(value >> 8);
                buffer[offset + 7] = (byte)value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToInt64(this byte[] bytes, int offset = 0, bool? asLittleEndian = null)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
            if (bytes.Length == 0)
                return 0;
            if (bytes.Length <= offset)
                throw new InvalidOperationException("Array length must be greater than offset.");
            bool isLittleEndian = ExtendedBitConverter.GetIsLittleEndian(asLittleEndian);
            ExtendedBitConverter.EnsureLength(ref bytes, 8, offset, isLittleEndian);
            return !isLittleEndian ? (long)bytes[offset] << 56 | (long)bytes[offset + 1] << 48 | (long)bytes[offset + 2] << 40 | (long)bytes[offset + 3] << 32 | (long)bytes[offset + 4] << 24 | (long)bytes[offset + 5] << 16 | (long)bytes[offset + 6] << 8 | (long)bytes[offset + 7] : (long)bytes[offset] | (long)bytes[offset + 1] << 8 | (long)bytes[offset + 2] << 16 | (long)bytes[offset + 3] << 24 | (long)bytes[offset + 4] << 32 | (long)bytes[offset + 5] << 40 | (long)bytes[offset + 6] << 48 | (long)bytes[offset + 7] << 56;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToBytes(this ulong value, bool? asLittleEndian = null) => ((long)value).ToBytes(asLittleEndian);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBytes(this ulong value, byte[] buffer, int offset = 0, bool? asLittleEndian = null) => ((long)value).ToBytes(buffer, offset, asLittleEndian);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ToUInt64(this byte[] bytes, int offset = 0, bool? asLittleEndian = null) => (ulong)bytes.ToInt64(offset, asLittleEndian);

        public static void ToBytes(this Int128 value, byte[] buffer, int offset = 0, bool? asLittleEndian = null)
        {
            bool isLittleEndian = ExtendedBitConverter.GetIsLittleEndian(asLittleEndian);
            value.Low.ToBytes(buffer, isLittleEndian ? offset : offset + 8, new bool?(isLittleEndian));
            value.High.ToBytes(buffer, isLittleEndian ? offset + 8 : offset, new bool?(isLittleEndian));
        }

        public static byte[] ToBytes(this Int128 value, bool? asLittleEndian = null, bool trimZeros = false)
        {
            byte[] bytes = new byte[16];
            value.ToBytes(bytes, asLittleEndian: asLittleEndian);
            if (trimZeros)
                bytes = bytes.TrimZeros(asLittleEndian);
            return bytes;
        }

        public static Int128 ToInt128(this byte[] bytes, int offset = 0, bool? asLittleEndian = null)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
            if (bytes.Length == 0)
                return (Int128)0;
            if (bytes.Length <= offset)
                throw new InvalidOperationException("Array length must be greater than offset.");
            bool isLittleEndian = ExtendedBitConverter.GetIsLittleEndian(asLittleEndian);
            ExtendedBitConverter.EnsureLength(ref bytes, 16, offset, isLittleEndian);
            return new Int128(bytes.ToUInt64(isLittleEndian ? offset + 8 : offset, new bool?(isLittleEndian)), bytes.ToUInt64(isLittleEndian ? offset : offset + 8, new bool?(isLittleEndian)));
        }

        public static void ToBytes(this Int256 value, byte[] buffer, int offset = 0, bool? asLittleEndian = null)
        {
            bool isLittleEndian = ExtendedBitConverter.GetIsLittleEndian(asLittleEndian);
            value.D.ToBytes(buffer, isLittleEndian ? offset : offset + 24, new bool?(isLittleEndian));
            value.C.ToBytes(buffer, isLittleEndian ? offset + 8 : offset + 16, new bool?(isLittleEndian));
            value.B.ToBytes(buffer, isLittleEndian ? offset + 16 : offset + 8, new bool?(isLittleEndian));
            value.A.ToBytes(buffer, isLittleEndian ? offset + 24 : offset, new bool?(isLittleEndian));
        }

        public static byte[] ToBytes(this Int256 value, bool? asLittleEndian = null, bool trimZeros = false)
        {
            byte[] bytes = new byte[32];
            value.ToBytes(bytes, asLittleEndian: asLittleEndian);
            if (trimZeros)
                bytes = bytes.TrimZeros(asLittleEndian);
            return bytes;
        }

        public static Int256 ToInt256(this byte[] bytes, int offset = 0, bool? asLittleEndian = null)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
            if (bytes.Length == 0)
                return (Int256)0;
            if (bytes.Length <= offset)
                throw new InvalidOperationException("Array length must be greater than offset.");
            bool isLittleEndian = ExtendedBitConverter.GetIsLittleEndian(asLittleEndian);
            ExtendedBitConverter.EnsureLength(ref bytes, 32, offset, isLittleEndian);
            long uint64_1 = (long)bytes.ToUInt64(isLittleEndian ? offset + 24 : offset, new bool?(isLittleEndian));
            ulong uint64_2 = bytes.ToUInt64(isLittleEndian ? offset + 16 : offset + 8, new bool?(isLittleEndian));
            ulong uint64_3 = bytes.ToUInt64(isLittleEndian ? offset + 8 : offset + 16, new bool?(isLittleEndian));
            ulong uint64_4 = bytes.ToUInt64(isLittleEndian ? offset : offset + 24, new bool?(isLittleEndian));
            long b = (long)uint64_2;
            long c = (long)uint64_3;
            long d = (long)uint64_4;
            return new Int256((ulong)uint64_1, (ulong)b, (ulong)c, (ulong)d);
        }
    }
}
