using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(913498268)]
  public class TLRequestGetPeerSettings : TLMethod
  {
    public override int Constructor => 913498268;

    public TLAbsInputPeer Peer { get; set; }

    public TLPeerSettings Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLPeerSettings) ObjectUtils.DeserializeObject(br);
  }
}
