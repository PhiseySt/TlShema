using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(634833351)]
  public class TLUpdateReadChannelOutbox : TLAbsUpdate
  {
    public override int Constructor => 634833351;

    public int ChannelId { get; set; }

    public int MaxId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ChannelId = br.ReadInt32();
      this.MaxId = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChannelId);
      bw.Write(this.MaxId);
    }
  }
}
