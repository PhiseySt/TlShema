using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1618676578)]
  public class TLMessageMediaUnsupported : TLAbsMessageMedia
  {
    public override int Constructor => -1618676578;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
