using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1599050311)]
  public class TLContactLinkUnknown : TLAbsContactLink
  {
    public override int Constructor => 1599050311;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
