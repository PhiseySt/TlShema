using System.IO;

namespace Abdt.Babdt.TlShema
{
    internal class BoolUtil
    {
        public static bool Deserialize(BinaryReader reader)
        {
            int num1 = -1132882121;
            int num2 = -1720552011;
            int num3 = reader.ReadInt32();
            if (num3 == num1)
                return false;
            if (num3 == num2)
                return true;
            throw new InvalidDataException(string.Format("Invalid Boolean Data : {0}", (object)num3.ToString()));
        }

        public static void Serialize(bool src, BinaryWriter writer)
        {
            int num1 = -1132882121;
            int num2 = -1720552011;
            writer.Write(src ? num2 : num1);
        }
    }
}
