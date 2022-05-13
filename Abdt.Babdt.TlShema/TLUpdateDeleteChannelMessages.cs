using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1015733815)]
  public class TLUpdateDeleteChannelMessages : TLAbsUpdate
  {
    public override int Constructor => -1015733815;

    public int ChannelId { get; set; }

    public TLVector<int> Messages { get; set; }

    public int Pts { get; set; }

    public int PtsCount { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ChannelId = br.ReadInt32();
      this.Messages = ObjectUtils.DeserializeVector<int>(br);
      this.Pts = br.ReadInt32();
      this.PtsCount = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChannelId);
      ObjectUtils.SerializeObject((object) this.Messages, bw);
      bw.Write(this.Pts);
      bw.Write(this.PtsCount);
    }
  }
}
