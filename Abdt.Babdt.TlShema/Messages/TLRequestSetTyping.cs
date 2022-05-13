using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-1551737264)]
  public class TLRequestSetTyping : TLMethod
  {
    public override int Constructor => -1551737264;

    public TLAbsInputPeer Peer { get; set; }

    public TLAbsSendMessageAction Action { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.Action = (TLAbsSendMessageAction) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      ObjectUtils.SerializeObject((object) this.Action, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
