using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1613493288)]
  public class TLNotifyPeer : TLAbsNotifyPeer
  {
    public override int Constructor => -1613493288;

    public TLAbsPeer Peer { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Peer = (TLAbsPeer) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
    }
  }
}
