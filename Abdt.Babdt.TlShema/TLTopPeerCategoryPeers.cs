using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-75283823)]
  public class TLTopPeerCategoryPeers : TLObject
  {
    public override int Constructor => -75283823;

    public TLAbsTopPeerCategory Category { get; set; }

    public int Count { get; set; }

    public TLVector<TLTopPeer> Peers { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Category = (TLAbsTopPeerCategory) ObjectUtils.DeserializeObject(br);
      this.Count = br.ReadInt32();
      this.Peers = ObjectUtils.DeserializeVector<TLTopPeer>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Category, bw);
      bw.Write(this.Count);
      ObjectUtils.SerializeObject((object) this.Peers, bw);
    }
  }
}
