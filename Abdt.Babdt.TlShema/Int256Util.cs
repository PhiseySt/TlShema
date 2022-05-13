using System.IO;

namespace Abdt.Babdt.TlShema
{
    internal class Int256Util
    {
        public static Int256 Deserialize(BinaryReader reader) => reader.ReadBytes(32).ToInt256(asLittleEndian: new bool?(true));

        public static void Serialize(Int256 src, BinaryWriter writer) => writer.Write(src.ToBytes(new bool?(true)));
    }
}
