using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-721239344)]
  public class TLContactLinkContact : TLAbsContactLink
  {
    public override int Constructor => -721239344;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
