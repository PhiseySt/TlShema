using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-697604407)]
  public class TLInputPrivacyValueDisallowAll : TLAbsInputPrivacyRule
  {
    public override int Constructor => -697604407;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
