using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(-1374118561)]
  public class TLRequestReportPeer : TLMethod
  {
    public override int Constructor => -1374118561;

    public TLAbsInputPeer Peer { get; set; }

    public TLAbsReportReason Reason { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.Reason = (TLAbsReportReason) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      ObjectUtils.SerializeObject((object) this.Reason, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
