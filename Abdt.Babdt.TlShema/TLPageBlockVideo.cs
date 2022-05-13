using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-640214938)]
  public class TLPageBlockVideo : TLAbsPageBlock
  {
    public override int Constructor => -640214938;

    public int Flags { get; set; }

    public bool Autoplay { get; set; }

    public bool Loop { get; set; }

    public long VideoId { get; set; }

    public TLAbsRichText Caption { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Autoplay ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Loop ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Autoplay = (uint) (this.Flags & 1) > 0U;
      this.Loop = (uint) (this.Flags & 2) > 0U;
      this.VideoId = br.ReadInt64();
      this.Caption = (TLAbsRichText) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.VideoId);
      ObjectUtils.SerializeObject((object) this.Caption, bw);
    }
  }
}
