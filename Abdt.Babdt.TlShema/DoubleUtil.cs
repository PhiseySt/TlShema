using System.IO;

namespace Abdt.Babdt.TlShema
{
    internal class DoubleUtil
    {
        public static double Deserialize(BinaryReader reader) => reader.ReadDouble();

        public static void Serialize(double src, BinaryWriter writer) => writer.Write(src);
    }
}
