﻿using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-103646630)]
  public class TLUpdateInlineBotCallbackQuery : TLAbsUpdate
  {
    public override int Constructor => -103646630;

    public int Flags { get; set; }

    public long QueryId { get; set; }

    public int UserId { get; set; }

    public TLInputBotInlineMessageID MsgId { get; set; }

    public long ChatInstance { get; set; }

    public byte[] Data { get; set; }

    public string GameShortName { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Data != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.GameShortName != null ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.QueryId = br.ReadInt64();
      this.UserId = br.ReadInt32();
      this.MsgId = (TLInputBotInlineMessageID) ObjectUtils.DeserializeObject(br);
      this.ChatInstance = br.ReadInt64();
      this.Data = (this.Flags & 1) == 0 ? (byte[]) null : BytesUtil.Deserialize(br);
      if ((this.Flags & 2) != 0)
        this.GameShortName = StringUtil.Deserialize(br);
      else
        this.GameShortName = (string) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.QueryId);
      bw.Write(this.UserId);
      ObjectUtils.SerializeObject((object) this.MsgId, bw);
      bw.Write(this.ChatInstance);
      if ((this.Flags & 1) != 0)
        BytesUtil.Serialize(this.Data, bw);
      if ((this.Flags & 2) == 0)
        return;
      StringUtil.Serialize(this.GameShortName, bw);
    }
  }
}
