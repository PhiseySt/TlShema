using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(377562760)]
  public class TLUpdateShortChatMessage : TLAbsUpdates
  {
    public override int Constructor => 377562760;

    public int Flags { get; set; }

    public bool Out { get; set; }

    public bool Mentioned { get; set; }

    public bool MediaUnread { get; set; }

    public bool Silent { get; set; }

    public int Id { get; set; }

    public int FromId { get; set; }

    public int ChatId { get; set; }

    public string Message { get; set; }

    public int Pts { get; set; }

    public int PtsCount { get; set; }

    public int Date { get; set; }

    public TLMessageFwdHeader FwdFrom { get; set; }

    public int? ViaBotId { get; set; }

    public int? ReplyToMsgId { get; set; }

    public TLVector<TLAbsMessageEntity> Entities { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Out ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Mentioned ? this.Flags | 16 : this.Flags & -17;
      this.Flags = this.MediaUnread ? this.Flags | 32 : this.Flags & -33;
      this.Flags = this.Silent ? this.Flags | 8192 : this.Flags & -8193;
      this.Flags = this.FwdFrom != null ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.ViaBotId.HasValue ? this.Flags | 2048 : this.Flags & -2049;
      this.Flags = this.ReplyToMsgId.HasValue ? this.Flags | 8 : this.Flags & -9;
      this.Flags = this.Entities != null ? this.Flags | 128 : this.Flags & -129;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Out = (uint) (this.Flags & 2) > 0U;
      this.Mentioned = (uint) (this.Flags & 16) > 0U;
      this.MediaUnread = (uint) (this.Flags & 32) > 0U;
      this.Silent = (uint) (this.Flags & 8192) > 0U;
      this.Id = br.ReadInt32();
      this.FromId = br.ReadInt32();
      this.ChatId = br.ReadInt32();
      this.Message = StringUtil.Deserialize(br);
      this.Pts = br.ReadInt32();
      this.PtsCount = br.ReadInt32();
      this.Date = br.ReadInt32();
      this.FwdFrom = (this.Flags & 4) == 0 ? (TLMessageFwdHeader) null : (TLMessageFwdHeader) ObjectUtils.DeserializeObject(br);
      this.ViaBotId = (this.Flags & 2048) == 0 ? new int?() : new int?(br.ReadInt32());
      this.ReplyToMsgId = (this.Flags & 8) == 0 ? new int?() : new int?(br.ReadInt32());
      if ((this.Flags & 128) != 0)
        this.Entities = ObjectUtils.DeserializeVector<TLAbsMessageEntity>(br);
      else
        this.Entities = (TLVector<TLAbsMessageEntity>) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Id);
      bw.Write(this.FromId);
      bw.Write(this.ChatId);
      StringUtil.Serialize(this.Message, bw);
      bw.Write(this.Pts);
      bw.Write(this.PtsCount);
      bw.Write(this.Date);
      if ((this.Flags & 4) != 0)
        ObjectUtils.SerializeObject((object) this.FwdFrom, bw);
      if ((this.Flags & 2048) != 0)
        bw.Write(this.ViaBotId.Value);
      if ((this.Flags & 8) != 0)
        bw.Write(this.ReplyToMsgId.Value);
      if ((this.Flags & 128) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.Entities, bw);
    }
  }
}
