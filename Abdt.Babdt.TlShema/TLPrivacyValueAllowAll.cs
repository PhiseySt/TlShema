using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1698855810)]
  public class TLPrivacyValueAllowAll : TLAbsPrivacyRule
  {
    public override int Constructor => 1698855810;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
