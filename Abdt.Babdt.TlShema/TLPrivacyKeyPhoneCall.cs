using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1030105979)]
  public class TLPrivacyKeyPhoneCall : TLAbsPrivacyKey
  {
    public override int Constructor => 1030105979;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
