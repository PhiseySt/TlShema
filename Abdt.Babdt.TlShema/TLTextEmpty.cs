using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-599948721)]
  public class TLTextEmpty : TLAbsRichText
  {
    public override int Constructor => -599948721;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
