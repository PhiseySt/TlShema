using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-40996577)]
  public class TLDraftMessage : TLAbsDraftMessage
  {
    public override int Constructor => -40996577;

    public int Flags { get; set; }

    public bool NoWebpage { get; set; }

    public int? ReplyToMsgId { get; set; }

    public string Message { get; set; }

    public TLVector<TLAbsMessageEntity> Entities { get; set; }

    public int Date { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.NoWebpage ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.ReplyToMsgId.HasValue ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Entities != null ? this.Flags | 8 : this.Flags & -9;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.NoWebpage = (uint) (this.Flags & 2) > 0U;
      this.ReplyToMsgId = (this.Flags & 1) == 0 ? new int?() : new int?(br.ReadInt32());
      this.Message = StringUtil.Deserialize(br);
      this.Entities = (this.Flags & 8) == 0 ? (TLVector<TLAbsMessageEntity>) null : ObjectUtils.DeserializeVector<TLAbsMessageEntity>(br);
      this.Date = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      if ((this.Flags & 1) != 0)
        bw.Write(this.ReplyToMsgId.Value);
      StringUtil.Serialize(this.Message, bw);
      if ((this.Flags & 8) != 0)
        ObjectUtils.SerializeObject((object) this.Entities, bw);
      bw.Write(this.Date);
    }
  }
}
