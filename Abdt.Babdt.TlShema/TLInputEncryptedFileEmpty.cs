using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(406307684)]
  public class TLInputEncryptedFileEmpty : TLAbsInputEncryptedFile
  {
    public override int Constructor => 406307684;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
