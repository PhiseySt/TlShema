using System.IO;

namespace Abdt.Babdt.TlShema
{
    internal class IntegerUtil
    {
        public static int Deserialize(BinaryReader reader) => reader.ReadInt32();

        public static void Serialize(int src, BinaryWriter writer) => writer.Write(src);
    }
}
