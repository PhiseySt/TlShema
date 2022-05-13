using System.IO;

namespace Abdt.Babdt.TlShema
{
    internal class Int128Util
    {
        public static Int128 Deserialize(BinaryReader reader) => reader.ReadBytes(16).ToInt128(asLittleEndian: new bool?(true));

        public static void Serialize(Int128 src, BinaryWriter writer) => writer.Write(src.ToBytes(new bool?(true)));
    }
}
