using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(457133559)]
  public class TLUpdateEditChannelMessage : TLAbsUpdate
  {
    public override int Constructor => 457133559;

    public TLAbsMessage Message { get; set; }

    public int Pts { get; set; }

    public int PtsCount { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Message = (TLAbsMessage) ObjectUtils.DeserializeObject(br);
      this.Pts = br.ReadInt32();
      this.PtsCount = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Message, bw);
      bw.Write(this.Pts);
      bw.Write(this.PtsCount);
    }
  }
}
