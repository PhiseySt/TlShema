using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-91733382)]
  public class TLRequestSendMessage : TLMethod
  {
    public override int Constructor => -91733382;

    public int Flags { get; set; }

    public bool NoWebpage { get; set; }

    public bool Silent { get; set; }

    public bool Background { get; set; }

    public bool ClearDraft { get; set; }

    public TLAbsInputPeer Peer { get; set; }

    public int? ReplyToMsgId { get; set; }

    public string Message { get; set; }

    public long RandomId { get; set; }

    public TLAbsReplyMarkup ReplyMarkup { get; set; }

    public TLVector<TLAbsMessageEntity> Entities { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.NoWebpage ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Silent ? this.Flags | 32 : this.Flags & -33;
      this.Flags = this.Background ? this.Flags | 64 : this.Flags & -65;
      this.Flags = this.ClearDraft ? this.Flags | 128 : this.Flags & -129;
      this.Flags = this.ReplyToMsgId.HasValue ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.ReplyMarkup != null ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.Entities != null ? this.Flags | 8 : this.Flags & -9;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.NoWebpage = (uint) (this.Flags & 2) > 0U;
      this.Silent = (uint) (this.Flags & 32) > 0U;
      this.Background = (uint) (this.Flags & 64) > 0U;
      this.ClearDraft = (uint) (this.Flags & 128) > 0U;
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.ReplyToMsgId = (this.Flags & 1) == 0 ? new int?() : new int?(br.ReadInt32());
      this.Message = StringUtil.Deserialize(br);
      this.RandomId = br.ReadInt64();
      this.ReplyMarkup = (this.Flags & 4) == 0 ? (TLAbsReplyMarkup) null : (TLAbsReplyMarkup) ObjectUtils.DeserializeObject(br);
      if ((this.Flags & 8) != 0)
        this.Entities = ObjectUtils.DeserializeVector<TLAbsMessageEntity>(br);
      else
        this.Entities = (TLVector<TLAbsMessageEntity>) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      if ((this.Flags & 1) != 0)
        bw.Write(this.ReplyToMsgId.Value);
      StringUtil.Serialize(this.Message, bw);
      bw.Write(this.RandomId);
      if ((this.Flags & 4) != 0)
        ObjectUtils.SerializeObject((object) this.ReplyMarkup, bw);
      if ((this.Flags & 8) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.Entities, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
