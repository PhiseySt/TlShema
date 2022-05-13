using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(313765169)]
  public class TLRequestGetNotifySettings : TLMethod
  {
    public override int Constructor => 313765169;

    public TLAbsInputNotifyPeer Peer { get; set; }

    public TLAbsPeerNotifySettings Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Peer = (TLAbsInputNotifyPeer) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsPeerNotifySettings) ObjectUtils.DeserializeObject(br);
  }
}
