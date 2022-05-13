using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(-623130288)]
  public class TLRequestGetPrivacy : TLMethod
  {
    public override int Constructor => -623130288;

    public TLAbsInputPrivacyKey Key { get; set; }

    public TLPrivacyRules Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Key = (TLAbsInputPrivacyKey) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Key, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLPrivacyRules) ObjectUtils.DeserializeObject(br);
  }
}
