using System.IO;

namespace Abdt.Babdt.TlShema.Phone
{
  [TLObject(2027164582)]
  public class TLRequestDiscardCall : TLMethod
  {
    public override int Constructor => 2027164582;

    public TLInputPhoneCall Peer { get; set; }

    public int Duration { get; set; }

    public TLAbsPhoneCallDiscardReason Reason { get; set; }

    public long ConnectionId { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLInputPhoneCall) ObjectUtils.DeserializeObject(br);
      this.Duration = br.ReadInt32();
      this.Reason = (TLAbsPhoneCallDiscardReason) ObjectUtils.DeserializeObject(br);
      this.ConnectionId = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.Duration);
      ObjectUtils.SerializeObject((object) this.Reason, bw);
      bw.Write(this.ConnectionId);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
