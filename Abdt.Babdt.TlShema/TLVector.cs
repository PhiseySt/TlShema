using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(481674261)]
  public class TLVector : TLObject
  {
    public override int Constructor => 481674261;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
