using System.IO;

namespace Abdt.Babdt.TlShema.Phone
{
  [TLObject(399855457)]
  public class TLRequestReceivedCall : TLMethod
  {
    public override int Constructor => 399855457;

    public TLInputPhoneCall Peer { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Peer = (TLInputPhoneCall) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
