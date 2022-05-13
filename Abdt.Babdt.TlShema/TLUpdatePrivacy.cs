using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-298113238)]
  public class TLUpdatePrivacy : TLAbsUpdate
  {
    public override int Constructor => -298113238;

    public TLAbsPrivacyKey Key { get; set; }

    public TLVector<TLAbsPrivacyRule> Rules { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Key = (TLAbsPrivacyKey) ObjectUtils.DeserializeObject(br);
      this.Rules = ObjectUtils.DeserializeVector<TLAbsPrivacyRule>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Key, bw);
      ObjectUtils.SerializeObject((object) this.Rules, bw);
    }
  }
}
