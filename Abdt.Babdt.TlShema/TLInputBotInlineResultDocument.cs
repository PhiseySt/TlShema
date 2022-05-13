using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-459324)]
  public class TLInputBotInlineResultDocument : TLAbsInputBotInlineResult
  {
    public override int Constructor => -459324;

    public int Flags { get; set; }

    public string Id { get; set; }

    public string Type { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public TLAbsInputDocument Document { get; set; }

    public TLAbsInputBotInlineMessage SendMessage { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Title != null ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Description != null ? this.Flags | 4 : this.Flags & -5;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Id = StringUtil.Deserialize(br);
      this.Type = StringUtil.Deserialize(br);
      this.Title = (this.Flags & 2) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Description = (this.Flags & 4) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Document = (TLAbsInputDocument) ObjectUtils.DeserializeObject(br);
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
      ObjectUtils.SerializeObject((object) this.Document, bw);
      ObjectUtils.SerializeObject((object) this.SendMessage, bw);
    }
  }
}
