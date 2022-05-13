using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(-906486552)]
  public class TLRequestSetPrivacy : TLMethod
  {
    public override int Constructor => -906486552;

    public TLAbsInputPrivacyKey Key { get; set; }

    public TLVector<TLAbsInputPrivacyRule> Rules { get; set; }

    public TLPrivacyRules Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Key = (TLAbsInputPrivacyKey) ObjectUtils.DeserializeObject(br);
      this.Rules = ObjectUtils.DeserializeVector<TLAbsInputPrivacyRule>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Key, bw);
      ObjectUtils.SerializeObject((object) this.Rules, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLPrivacyRules) ObjectUtils.DeserializeObject(br);
  }
}
