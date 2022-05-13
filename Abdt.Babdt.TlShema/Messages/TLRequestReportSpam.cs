using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-820669733)]
  public class TLRequestReportSpam : TLMethod
  {
    public override int Constructor => -820669733;

    public TLAbsInputPeer Peer { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
