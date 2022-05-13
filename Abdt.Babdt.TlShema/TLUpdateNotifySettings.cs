using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1094555409)]
  public class TLUpdateNotifySettings : TLAbsUpdate
  {
    public override int Constructor => -1094555409;

    public TLAbsNotifyPeer Peer { get; set; }

    public TLAbsPeerNotifySettings NotifySettings { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLAbsNotifyPeer) ObjectUtils.DeserializeObject(br);
      this.NotifySettings = (TLAbsPeerNotifySettings) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      ObjectUtils.SerializeObject((object) this.NotifySettings, bw);
    }
  }
}
