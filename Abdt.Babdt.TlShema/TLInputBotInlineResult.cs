using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(750510426)]
  public class TLInputBotInlineResult : TLAbsInputBotInlineResult
  {
    public override int Constructor => 750510426;

    public int Flags { get; set; }

    public string Id { get; set; }

    public string Type { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Url { get; set; }

    public string ThumbUrl { get; set; }

    public string ContentUrl { get; set; }

    public string ContentType { get; set; }

    public int? W { get; set; }

    public int? H { get; set; }

    public int? Duration { get; set; }

    public TLAbsInputBotInlineMessage SendMessage { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Title != null ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Description != null ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.Url != null ? this.Flags | 8 : this.Flags & -9;
      this.Flags = this.ThumbUrl != null ? this.Flags | 16 : this.Flags & -17;
      this.Flags = this.ContentUrl != null ? this.Flags | 32 : this.Flags & -33;
      this.Flags = this.ContentType != null ? this.Flags | 32 : this.Flags & -33;
      this.Flags = this.W.HasValue ? this.Flags | 64 : this.Flags & -65;
      this.Flags = this.H.HasValue ? this.Flags | 64 : this.Flags & -65;
      this.Flags = this.Duration.HasValue ? this.Flags | 128 : this.Flags & -129;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Id = StringUtil.Deserialize(br);
      this.Type = StringUtil.Deserialize(br);
      this.Title = (this.Flags & 2) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Description = (this.Flags & 4) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Url = (this.Flags & 8) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.ThumbUrl = (this.Flags & 16) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.ContentUrl = (this.Flags & 32) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.ContentType = (this.Flags & 32) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.W = (this.Flags & 64) == 0 ? new int?() : new int?(br.ReadInt32());
      this.H = (this.Flags & 64) == 0 ? new int?() : new int?(br.ReadInt32());
      this.Duration = (this.Flags & 128) == 0 ? new int?() : new int?(br.ReadInt32());
      this.SendMessage = (TLAbsInputBotInlineMessage) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      StringUtil.Serialize(this.Id, bw);
      StringUtil.Serialize(this.Type, bw);
      if ((this.Flags & 2) != 0)
        StringUtil.Serialize(this.Title, bw);
      if ((this.Flags & 4) != 0)
        StringUtil.Serialize(this.Description, bw);
      if ((this.Flags & 8) != 0)
        StringUtil.Serialize(this.Url, bw);
      if ((this.Flags & 16) != 0)
        StringUtil.Serialize(this.ThumbUrl, bw);
      if ((this.Flags & 32) != 0)
        StringUtil.Serialize(this.ContentUrl, bw);
      if ((this.Flags & 32) != 0)
        StringUtil.Serialize(this.ContentType, bw);
      if ((this.Flags & 64) != 0)
        bw.Write(this.W.Value);
      if ((this.Flags & 64) != 0)
        bw.Write(this.H.Value);
      if ((this.Flags & 128) != 0)
        bw.Write(this.Duration.Value);
      ObjectUtils.SerializeObject((object) this.SendMessage, bw);
    }
  }
}
