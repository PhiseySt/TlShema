using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1195615476)]
  public class TLInputNotifyPeer : TLAbsInputNotifyPeer
  {
    public override int Constructor => -1195615476;

    public TLAbsInputPeer Peer { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
    }
  }
}
