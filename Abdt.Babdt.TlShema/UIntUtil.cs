using System.IO;

namespace Abdt.Babdt.TlShema
{
  internal class UIntUtil
  {
    public static uint Deserialize(BinaryReader reader) => reader.ReadUInt32();

    public static void Serialize(uint src, BinaryWriter writer) => writer.Write(src);
  }
}
