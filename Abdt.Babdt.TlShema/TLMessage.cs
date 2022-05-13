using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1063525281)]
  public class TLMessage : TLAbsMessage
  {
    public override int Constructor => -1063525281;

    public int Flags { get; set; }

    public bool Out { get; set; }

    public bool Mentioned { get; set; }

    public bool MediaUnread { get; set; }

    public bool Silent { get; set; }

    public bool Post { get; set; }

    public int Id { get; set; }

    public int? FromId { get; set; }

    public TLAbsPeer ToId { get; set; }

    public TLMessageFwdHeader FwdFrom { get; set; }

    public int? ViaBotId { get; set; }

    public int? ReplyToMsgId { get; set; }

    public int Date { get; set; }

    public string Message { get; set; }

    public TLAbsMessageMedia Media { get; set; }

    public TLAbsReplyMarkup ReplyMarkup { get; set; }

    public TLVector<TLAbsMessageEntity> Entities { get; set; }

    public int? Views { get; set; }

    public int? EditDate { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Out ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Mentioned ? this.Flags | 16 : this.Flags & -17;
      this.Flags = this.MediaUnread ? this.Flags | 32 : this.Flags & -33;
      this.Flags = this.Silent ? this.Flags | 8192 : this.Flags & -8193;
      this.Flags = this.Post ? this.Flags | 16384 : this.Flags & -16385;
      this.Flags = this.FromId.HasValue ? this.Flags | 256 : this.Flags & -257;
      this.Flags = this.FwdFrom != null ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.ViaBotId.HasValue ? this.Flags | 2048 : this.Flags & -2049;
      this.Flags = this.ReplyToMsgId.HasValue ? this.Flags | 8 : this.Flags & -9;
      this.Flags = this.Media != null ? this.Flags | 512 : this.Flags & -513;
      this.Flags = this.ReplyMarkup != null ? this.Flags | 64 : this.Flags & -65;
      this.Flags = this.Entities != null ? this.Flags | 128 : this.Flags & -129;
      this.Flags = this.Views.HasValue ? this.Flags | 1024 : this.Flags & -1025;
      this.Flags = this.EditDate.HasValue ? this.Flags | 32768 : this.Flags & -32769;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Out = (uint) (this.Flags & 2) > 0U;
      this.Mentioned = (uint) (this.Flags & 16) > 0U;
      this.MediaUnread = (uint) (this.Flags & 32) > 0U;
      this.Silent = (uint) (this.Flags & 8192) > 0U;
      this.Post = (uint) (this.Flags & 16384) > 0U;
      this.Id = br.ReadInt32();
      this.FromId = (this.Flags & 256) == 0 ? new int?() : new int?(br.ReadInt32());
      this.ToId = (TLAbsPeer) ObjectUtils.DeserializeObject(br);
      this.FwdFrom = (this.Flags & 4) == 0 ? (TLMessageFwdHeader) null : (TLMessageFwdHeader) ObjectUtils.DeserializeObject(br);
      this.ViaBotId = (this.Flags & 2048) == 0 ? new int?() : new int?(br.ReadInt32());
      this.ReplyToMsgId = (this.Flags & 8) == 0 ? new int?() : new int?(br.ReadInt32());
      this.Date = br.ReadInt32();
      this.Message = StringUtil.Deserialize(br);
      this.Media = (this.Flags & 512) == 0 ? (TLAbsMessageMedia) null : (TLAbsMessageMedia) ObjectUtils.DeserializeObject(br);
      this.ReplyMarkup = (this.Flags & 64) == 0 ? (TLAbsReplyMarkup) null : (TLAbsReplyMarkup) ObjectUtils.DeserializeObject(br);
      this.Entities = (this.Flags & 128) == 0 ? (TLVector<TLAbsMessageEntity>) null : ObjectUtils.DeserializeVector<TLAbsMessageEntity>(br);
      this.Views = (this.Flags & 1024) == 0 ? new int?() : new int?(br.ReadInt32());
      if ((this.Flags & 32768) != 0)
        this.EditDate = new int?(br.ReadInt32());
      else
        this.EditDate = new int?();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Id);
      if ((this.Flags & 256) != 0)
        bw.Write(this.FromId.Value);
      ObjectUtils.SerializeObject((object) this.ToId, bw);
      if ((this.Flags & 4) != 0)
        ObjectUtils.SerializeObject((object) this.FwdFrom, bw);
      if ((this.Flags & 2048) != 0)
        bw.Write(this.ViaBotId.Value);
      if ((this.Flags & 8) != 0)
        bw.Write(this.ReplyToMsgId.Value);
      bw.Write(this.Date);
      StringUtil.Serialize(this.Message, bw);
      if ((this.Flags & 512) != 0)
        ObjectUtils.SerializeObject((object) this.Media, bw);
      if ((this.Flags & 64) != 0)
        ObjectUtils.SerializeObject((object) this.ReplyMarkup, bw);
      if ((this.Flags & 128) != 0)
        ObjectUtils.SerializeObject((object) this.Entities, bw);
      if ((this.Flags & 1024) != 0)
        bw.Write(this.Views.Value);
      if ((this.Flags & 32768) == 0)
        return;
      bw.Write(this.EditDate.Value);
    }
  }
}
