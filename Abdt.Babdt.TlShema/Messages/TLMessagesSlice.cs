using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(189033187)]
  public class TLMessagesSlice : TLAbsMessages
  {
    public override int Constructor => 189033187;

    public int Count { get; set; }

    public TLVector<TLAbsMessage> Messages { get; set; }

    public TLVector<TLAbsChat> Chats { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Count = br.ReadInt32();
      this.Messages = ObjectUtils.DeserializeVector<TLAbsMessage>(br);
      this.Chats = ObjectUtils.DeserializeVector<TLAbsChat>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Count);
      ObjectUtils.SerializeObject((object) this.Messages, bw);
      ObjectUtils.SerializeObject((object) this.Chats, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
