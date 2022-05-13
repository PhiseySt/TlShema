using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-1137057461)]
  public class TLRequestSaveDraft : TLMethod
  {
    public override int Constructor => -1137057461;

    public int Flags { get; set; }

    public bool NoWebpage { get; set; }

    public int? ReplyToMsgId { get; set; }

    public TLAbsInputPeer Peer { get; set; }

    public string Message { get; set; }

    public TLVector<TLAbsMessageEntity> Entities { get; set; }

    public bool Response { get; set; }

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
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.Message = StringUtil.Deserialize(br);
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
      if ((this.Flags & 1) != 0)
        bw.Write(this.ReplyToMsgId.Value);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      StringUtil.Serialize(this.Message, bw);
      if ((this.Flags & 8) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.Entities, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
