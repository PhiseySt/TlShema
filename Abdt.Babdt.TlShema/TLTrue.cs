using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1072550713)]
  public class TLTrue : TLObject
  {
    public override int Constructor => 1072550713;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
