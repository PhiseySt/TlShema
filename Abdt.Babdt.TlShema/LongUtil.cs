using System.IO;

namespace Abdt.Babdt.TlShema
{
    internal class LongUtil
    {
        public static long Deserialize(BinaryReader reader) => reader.ReadInt64();

        public static void Serialize(long src, BinaryWriter writer) => writer.Write(src);
    }
}
