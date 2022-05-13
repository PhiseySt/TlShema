using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(791617983)]
  public class TLUpdateReadHistoryOutbox : TLAbsUpdate
  {
    public override int Constructor => 791617983;

    public TLAbsPeer Peer { get; set; }

    public int MaxId { get; set; }

    public int Pts { get; set; }

    public int PtsCount { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLAbsPeer) ObjectUtils.DeserializeObject(br);
      this.MaxId = br.ReadInt32();
      this.Pts = br.ReadInt32();
      this.PtsCount = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.MaxId);
      bw.Write(this.Pts);
      bw.Write(this.PtsCount);
    }
  }
}
