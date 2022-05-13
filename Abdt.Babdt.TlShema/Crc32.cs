using System;
using System.Text;

namespace Abdt.Babdt.TlShema
{
    internal class Crc32
    {
        private const uint KCrcPoly = 3988292384;
        private const uint KInitial = 4294967295;
        private const uint CrcNumTables = 8;
        private static readonly uint[] Table = new uint[2048];
        private uint _value;

        static Crc32()
        {
            uint index1;
            for (index1 = 0U; index1 < 256U; ++index1)
            {
                uint num = index1;
                for (int index2 = 0; index2 < 8; ++index2)
                    num = num >> 1 ^ (uint)(-306674912 & ~(((int)num & 1) - 1));
                Crc32.Table[(int)index1] = num;
            }
            for (; index1 < 2048U; ++index1)
            {
                uint num = Crc32.Table[(int)index1 - 256];
                Crc32.Table[(int)index1] = Crc32.Table[(int)num & (int)byte.MaxValue] ^ num >> 8;
            }
        }

        public Crc32() => this.Init();

        public uint Value => ~this._value;

        public void Init() => this._value = uint.MaxValue;

        public void UpdateByte(byte b) => this._value = this._value >> 8 ^ Crc32.Table[(int)(byte)this._value ^ (int)b];

        public void Update(byte[] data, int offset, int count)
        {
            ArraySegment<byte> arraySegment = new ArraySegment<byte>(data, offset, count);
            if (count == 0)
                return;
            uint[] table = Crc32.Table;
            uint num1 = this._value;
            for (; (offset & 7) != 0 && count != 0; --count)
                num1 = num1 >> 8 ^ table[(int)(byte)num1 ^ (int)data[offset++]];
            if (count >= 8)
            {
                int num2 = count - 8 & -8;
                count -= num2;
                int num3 = num2 + offset;
                while (offset != num3)
                {
                    uint num4 = num1 ^ (uint)((int)data[offset] + ((int)data[offset + 1] << 8) + ((int)data[offset + 2] << 16) + ((int)data[offset + 3] << 24));
                    uint num5 = (uint)((int)data[offset + 4] + ((int)data[offset + 5] << 8) + ((int)data[offset + 6] << 16) + ((int)data[offset + 7] << 24));
                    offset += 8;
                    uint num6;
                    uint num7;
                    uint num8;
                    uint num9;
                    num1 = table[(int)(byte)num4 + 1792] ^ table[(int)(num6 = num4 >> 8) + 1536] ^ table[(int)(num7 = num6 >> 8) + 1280] ^ table[(int)(num7 >> 8) + 1024] ^ table[(int)(byte)num5 + 768] ^ table[(int)(num8 = num5 >> 8) + 512] ^ table[(int)(num9 = num8 >> 8) + 256] ^ table[(int)(num9 >> 8)];
                }
            }
            while (count-- != 0)
                num1 = num1 >> 8 ^ table[(int)(byte)num1 ^ (int)data[offset++]];
            this._value = num1;
        }

        public static uint Compute(byte[] data, int offset, int size)
        {
            Crc32 crc32 = new Crc32();
            crc32.Update(data, offset, size);
            return crc32.Value;
        }

        public static uint Compute(byte[] data) => Crc32.Compute(data, 0, data.Length);

        public static uint Compute(ArraySegment<byte> block) => Crc32.Compute(block.Array, block.Offset, block.Count);

        public static uint Compute(string text) => Crc32.Compute(text, Encoding.UTF8);

        public static uint Compute(string text, Encoding encoding) => Crc32.Compute(encoding.GetBytes(text));
    }
}
