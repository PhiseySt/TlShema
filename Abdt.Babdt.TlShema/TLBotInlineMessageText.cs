using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1937807902)]
  public class TLBotInlineMessageText : TLAbsBotInlineMessage
  {
    public override int Constructor => -1937807902;

    public int Flags { get; set; }

    public bool NoWebpage { get; set; }

    public string Message { get; set; }

    public TLVector<TLAbsMessageEntity> Entities { get; set; }

    public TLAbsReplyMarkup ReplyMarkup { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.NoWebpage ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Entities != null ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.ReplyMarkup != null ? this.Flags | 4 : this.Flags & -5;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.NoWebpage = (uint) (this.Flags & 1) > 0U;
      this.Message = StringUtil.Deserialize(br);
      this.Entities = (this.Flags & 2) == 0 ? (TLVector<TLAbsMessageEntity>) null : ObjectUtils.DeserializeVector<TLAbsMessageEntity>(br);
      if ((this.Flags & 4) != 0)
        this.ReplyMarkup = (TLAbsReplyMarkup) ObjectUtils.DeserializeObject(br);
      else
        this.ReplyMarkup = (TLAbsReplyMarkup) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      StringUtil.Serialize(this.Message, bw);
      if ((this.Flags & 2) != 0)
        ObjectUtils.SerializeObject((object) this.Entities, bw);
      if ((this.Flags & 4) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.ReplyMarkup, bw);
    }
  }
}
