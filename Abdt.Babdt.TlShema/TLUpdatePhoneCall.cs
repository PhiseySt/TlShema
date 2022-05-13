using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1425052898)]
  public class TLUpdatePhoneCall : TLAbsUpdate
  {
    public override int Constructor => -1425052898;

    public TLAbsPhoneCall PhoneCall { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.PhoneCall = (TLAbsPhoneCall) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.PhoneCall, bw);
    }
  }
}
