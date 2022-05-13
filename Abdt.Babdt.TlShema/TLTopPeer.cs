using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-305282981)]
  public class TLTopPeer : TLObject
  {
    public override int Constructor => -305282981;

    public TLAbsPeer Peer { get; set; }

    public double Rating { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLAbsPeer) ObjectUtils.DeserializeObject(br);
      this.Rating = br.ReadDouble();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.Rating);
    }
  }
}
