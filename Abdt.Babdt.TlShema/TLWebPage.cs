using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1594340540)]
  public class TLWebPage : TLAbsWebPage
  {
    public override int Constructor => 1594340540;

    public int Flags { get; set; }

    public long Id { get; set; }

    public string Url { get; set; }

    public string DisplayUrl { get; set; }

    public int Hash { get; set; }

    public string Type { get; set; }

    public string SiteName { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public TLAbsPhoto Photo { get; set; }

    public string EmbedUrl { get; set; }

    public string EmbedType { get; set; }

    public int? EmbedWidth { get; set; }

    public int? EmbedHeight { get; set; }

    public int? Duration { get; set; }

    public string Author { get; set; }

    public TLAbsDocument Document { get; set; }

    public TLAbsPage CachedPage { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Type != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.SiteName != null ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Title != null ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.Description != null ? this.Flags | 8 : this.Flags & -9;
      this.Flags = this.Photo != null ? this.Flags | 16 : this.Flags & -17;
      this.Flags = this.EmbedUrl != null ? this.Flags | 32 : this.Flags & -33;
      this.Flags = this.EmbedType != null ? this.Flags | 32 : this.Flags & -33;
      this.Flags = this.EmbedWidth.HasValue ? this.Flags | 64 : this.Flags & -65;
      this.Flags = this.EmbedHeight.HasValue ? this.Flags | 64 : this.Flags & -65;
      this.Flags = this.Duration.HasValue ? this.Flags | 128 : this.Flags & -129;
      this.Flags = this.Author != null ? this.Flags | 256 : this.Flags & -257;
      this.Flags = this.Document != null ? this.Flags | 512 : this.Flags & -513;
      this.Flags = this.CachedPage != null ? this.Flags | 1024 : this.Flags & -1025;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Id = br.ReadInt64();
      this.Url = StringUtil.Deserialize(br);
      this.DisplayUrl = StringUtil.Deserialize(br);
      this.Hash = br.ReadInt32();
      this.Type = (this.Flags & 1) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.SiteName = (this.Flags & 2) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Title = (this.Flags & 4) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Description = (this.Flags & 8) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Photo = (this.Flags & 16) == 0 ? (TLAbsPhoto) null : (TLAbsPhoto) ObjectUtils.DeserializeObject(br);
      this.EmbedUrl = (this.Flags & 32) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.EmbedType = (this.Flags & 32) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.EmbedWidth = (this.Flags & 64) == 0 ? new int?() : new int?(br.ReadInt32());
      this.EmbedHeight = (this.Flags & 64) == 0 ? new int?() : new int?(br.ReadInt32());
      this.Duration = (this.Flags & 128) == 0 ? new int?() : new int?(br.ReadInt32());
      this.Author = (this.Flags & 256) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Document = (this.Flags & 512) == 0 ? (TLAbsDocument) null : (TLAbsDocument) ObjectUtils.DeserializeObject(br);
      if ((this.Flags & 1024) != 0)
        this.CachedPage = (TLAbsPage) ObjectUtils.DeserializeObject(br);
      else
        this.CachedPage = (TLAbsPage) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Id);
      StringUtil.Serialize(this.Url, bw);
      StringUtil.Serialize(this.DisplayUrl, bw);
      bw.Write(this.Hash);
      if ((this.Flags & 1) != 0)
        StringUtil.Serialize(this.Type, bw);
      if ((this.Flags & 2) != 0)
        StringUtil.Serialize(this.SiteName, bw);
      if ((this.Flags & 4) != 0)
        StringUtil.Serialize(this.Title, bw);
      if ((this.Flags & 8) != 0)
        StringUtil.Serialize(this.Description, bw);
      if ((this.Flags & 16) != 0)
        ObjectUtils.SerializeObject((object) this.Photo, bw);
      if ((this.Flags & 32) != 0)
        StringUtil.Serialize(this.EmbedUrl, bw);
      if ((this.Flags & 32) != 0)
        StringUtil.Serialize(this.EmbedType, bw);
      if ((this.Flags & 64) != 0)
        bw.Write(this.EmbedWidth.Value);
      if ((this.Flags & 64) != 0)
        bw.Write(this.EmbedHeight.Value);
      if ((this.Flags & 128) != 0)
        bw.Write(this.Duration.Value);
      if ((this.Flags & 256) != 0)
        StringUtil.Serialize(this.Author, bw);
      if ((this.Flags & 512) != 0)
        ObjectUtils.SerializeObject((object) this.Document, bw);
      if ((this.Flags & 1024) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.CachedPage, bw);
    }
  }
}
