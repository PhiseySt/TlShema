using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1450380236)]
  public class TLNull : TLObject
  {
    public override int Constructor => 1450380236;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
