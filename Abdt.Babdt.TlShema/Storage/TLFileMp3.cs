using System.IO;

namespace Abdt.Babdt.TlShema.Storage
{
  [TLObject(1384777335)]
  public class TLFileMp3 : TLAbsFileType
  {
    public override int Constructor => 1384777335;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
