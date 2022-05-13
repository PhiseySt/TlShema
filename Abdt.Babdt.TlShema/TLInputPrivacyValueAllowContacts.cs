using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(218751099)]
  public class TLInputPrivacyValueAllowContacts : TLAbsInputPrivacyRule
  {
    public override int Constructor => 218751099;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
