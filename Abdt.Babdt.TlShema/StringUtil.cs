using System.IO;
using System.Text;

namespace Abdt.Babdt.TlShema
{
    internal class StringUtil
    {
        public static string Deserialize(BinaryReader reader)
        {
            byte[] bytes = BytesUtil.Deserialize(reader);
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }

        public static void Serialize(string src, BinaryWriter writer) => BytesUtil.Serialize(Encoding.UTF8.GetBytes(src), writer);
    }
}
