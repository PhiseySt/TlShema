using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1038967584)]
  public class TLMessageMediaEmpty : TLAbsMessageMedia
  {
    public override int Constructor => 1038967584;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
