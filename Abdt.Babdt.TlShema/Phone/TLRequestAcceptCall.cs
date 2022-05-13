using System.IO;

namespace Abdt.Babdt.TlShema.Phone
{
  [TLObject(1003664544)]
  public class TLRequestAcceptCall : TLMethod
  {
    public override int Constructor => 1003664544;

    public TLInputPhoneCall Peer { get; set; }

    public byte[] GB { get; set; }

    public TLPhoneCallProtocol Protocol { get; set; }

    public TLPhoneCall Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLInputPhoneCall) ObjectUtils.DeserializeObject(br);
      this.GB = BytesUtil.Deserialize(br);
      this.Protocol = (TLPhoneCallProtocol) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      BytesUtil.Serialize(this.GB, bw);
      ObjectUtils.SerializeObject((object) this.Protocol, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLPhoneCall) ObjectUtils.DeserializeObject(br);
  }
}
