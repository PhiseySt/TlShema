using System.IO;

namespace Abdt.Babdt.TlShema.Storage
{
  [TLObject(-1373745011)]
  public class TLFilePdf : TLAbsFileType
  {
    public override int Constructor => -1373745011;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
