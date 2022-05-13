using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-1318189314)]
  public class TLRequestSendInlineBotResult : TLMethod
  {
    public override int Constructor => -1318189314;

    public int Flags { get; set; }

    public bool Silent { get; set; }

    public bool Background { get; set; }

    public bool ClearDraft { get; set; }

    public TLAbsInputPeer Peer { get; set; }

    public int? ReplyToMsgId { get; set; }

    public long RandomId { get; set; }

    public long QueryId { get; set; }

    public string Id { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Silent ? this.Flags | 32 : this.Flags & -33;
      this.Flags = this.Background ? this.Flags | 64 : this.Flags & -65;
      this.Flags = this.ClearDraft ? this.Flags | 128 : this.Flags & -129;
      this.Flags = this.ReplyToMsgId.HasValue ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Silent = (uint) (this.Flags & 32) > 0U;
      this.Background = (uint) (this.Flags & 64) > 0U;
      this.ClearDraft = (uint) (this.Flags & 128) > 0U;
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.ReplyToMsgId = (this.Flags & 1) == 0 ? new int?() : new int?(br.ReadInt32());
      this.RandomId = br.ReadInt64();
      this.QueryId = br.ReadInt64();
      this.Id = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      if ((this.Flags & 1) != 0)
        bw.Write(this.ReplyToMsgId.Value);
      bw.Write(this.RandomId);
      bw.Write(this.QueryId);
      StringUtil.Serialize(this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
