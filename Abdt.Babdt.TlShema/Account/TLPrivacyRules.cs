using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(1430961007)]
  public class TLPrivacyRules : TLObject
  {
    public override int Constructor => 1430961007;

    public TLVector<TLAbsPrivacyRule> Rules { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Rules = ObjectUtils.DeserializeVector<TLAbsPrivacyRule>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Rules, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
