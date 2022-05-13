using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(-2067899501)]
  public class TLRequestUpdateNotifySettings : TLMethod
  {
    public override int Constructor => -2067899501;

    public TLAbsInputNotifyPeer Peer { get; set; }

    public TLInputPeerNotifySettings Settings { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLAbsInputNotifyPeer) ObjectUtils.DeserializeObject(br);
      this.Settings = (TLInputPeerNotifySettings) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      ObjectUtils.SerializeObject((object) this.Settings, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
