using System.IO;

namespace Abdt.Babdt.TlShema.Phone
{
  [TLObject(-326966976)]
  public class TLPhoneCall : TLObject
  {
    public override int Constructor => -326966976;

    public TLAbsPhoneCall PhoneCall { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PhoneCall = (TLAbsPhoneCall) ObjectUtils.DeserializeObject(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.PhoneCall, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
