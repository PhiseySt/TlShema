using System.IO;

namespace Abdt.Babdt.TlShema.Updates
{
  [TLObject(1091431943)]
  public class TLChannelDifferenceTooLong : TLAbsChannelDifference
  {
    public override int Constructor => 1091431943;

    public int Flags { get; set; }

    public bool Final { get; set; }

    public int Pts { get; set; }

    public int? Timeout { get; set; }

    public int TopMessage { get; set; }

    public int ReadInboxMaxId { get; set; }

    public int ReadOutboxMaxId { get; set; }

    public int UnreadCount { get; set; }

    public TLVector<TLAbsMessage> Messages { get; set; }

    public TLVector<TLAbsChat> Chats { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Final ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Timeout.HasValue ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Final = (uint) (this.Flags & 1) > 0U;
      this.Pts = br.ReadInt32();
      this.Timeout = (this.Flags & 2) == 0 ? new int?() : new int?(br.ReadInt32());
      this.TopMessage = br.ReadInt32();
      this.ReadInboxMaxId = br.ReadInt32();
      this.ReadOutboxMaxId = br.ReadInt32();
      this.UnreadCount = br.ReadInt32();
      this.Messages = ObjectUtils.DeserializeVector<TLAbsMessage>(br);
      this.Chats = ObjectUtils.DeserializeVector<TLAbsChat>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Pts);
      if ((this.Flags & 2) != 0)
        bw.Write(this.Timeout.Value);
      bw.Write(this.TopMessage);
      bw.Write(this.ReadInboxMaxId);
      bw.Write(this.ReadOutboxMaxId);
      bw.Write(this.UnreadCount);
      ObjectUtils.SerializeObject((object) this.Messages, bw);
      ObjectUtils.SerializeObject((object) this.Chats, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
