using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-840826671)]
  public class TLPageBlockEmbed : TLAbsPageBlock
  {
    public override int Constructor => -840826671;

    public int Flags { get; set; }

    public bool FullWidth { get; set; }

    public bool AllowScrolling { get; set; }

    public string Url { get; set; }

    public string Html { get; set; }

    public long? PosterPhotoId { get; set; }

    public int W { get; set; }

    public int H { get; set; }

    public TLAbsRichText Caption { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.FullWidth ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.AllowScrolling ? this.Flags | 8 : this.Flags & -9;
      this.Flags = this.Url != null ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Html != null ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.PosterPhotoId.HasValue ? this.Flags | 16 : this.Flags & -17;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.FullWidth = (uint) (this.Flags & 1) > 0U;
      this.AllowScrolling = (uint) (this.Flags & 8) > 0U;
      this.Url = (this.Flags & 2) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Html = (this.Flags & 4) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.PosterPhotoId = (this.Flags & 16) == 0 ? new long?() : new long?(br.ReadInt64());
      this.W = br.ReadInt32();
      this.H = br.ReadInt32();
      this.Caption = (TLAbsRichText) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      if ((this.Flags & 2) != 0)
        StringUtil.Serialize(this.Url, bw);
      if ((this.Flags & 4) != 0)
        StringUtil.Serialize(this.Html, bw);
      if ((this.Flags & 16) != 0)
        bw.Write(this.PosterPhotoId.Value);
      bw.Write(this.W);
      bw.Write(this.H);
      ObjectUtils.SerializeObject((object) this.Caption, bw);
    }
  }
}
