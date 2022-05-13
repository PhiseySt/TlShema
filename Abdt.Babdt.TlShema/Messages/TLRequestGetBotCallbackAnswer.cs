using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-2130010132)]
  public class TLRequestGetBotCallbackAnswer : TLMethod
  {
    public override int Constructor => -2130010132;

    public int Flags { get; set; }

    public bool Game { get; set; }

    public TLAbsInputPeer Peer { get; set; }

    public int MsgId { get; set; }

    public byte[] Data { get; set; }

    public TLBotCallbackAnswer Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Game ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Data != null ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Game = (uint) (this.Flags & 2) > 0U;
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.MsgId = br.ReadInt32();
      if ((this.Flags & 1) != 0)
        this.Data = BytesUtil.Deserialize(br);
      else
        this.Data = (byte[]) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.MsgId);
      if ((this.Flags & 1) == 0)
        return;
      BytesUtil.Serialize(this.Data, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLBotCallbackAnswer) ObjectUtils.DeserializeObject(br);
  }
}
