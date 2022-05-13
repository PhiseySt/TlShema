using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(324435594)]
  public class TLPageBlockUnsupported : TLAbsPageBlock
  {
    public override int Constructor => 324435594;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
