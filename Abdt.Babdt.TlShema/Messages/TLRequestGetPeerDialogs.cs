using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(764901049)]
  public class TLRequestGetPeerDialogs : TLMethod
  {
    public override int Constructor => 764901049;

    public TLVector<TLAbsInputPeer> Peers { get; set; }

    public TLPeerDialogs Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Peers = ObjectUtils.DeserializeVector<TLAbsInputPeer>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peers, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLPeerDialogs) ObjectUtils.DeserializeObject(br);
  }
}
