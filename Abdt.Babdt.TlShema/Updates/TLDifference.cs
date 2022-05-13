using System.IO;

namespace Abdt.Babdt.TlShema.Updates
{
  [TLObject(16030880)]
  public class TLDifference : TLAbsDifference
  {
    public override int Constructor => 16030880;

    public TLVector<TLAbsMessage> NewMessages { get; set; }

    public TLVector<TLAbsEncryptedMessage> NewEncryptedMessages { get; set; }

    public TLVector<TLAbsUpdate> OtherUpdates { get; set; }

    public TLVector<TLAbsChat> Chats { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public TLState State { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.NewMessages = ObjectUtils.DeserializeVector<TLAbsMessage>(br);
      this.NewEncryptedMessages = ObjectUtils.DeserializeVector<TLAbsEncryptedMessage>(br);
      this.OtherUpdates = ObjectUtils.DeserializeVector<TLAbsUpdate>(br);
      this.Chats = ObjectUtils.DeserializeVector<TLAbsChat>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
      this.State = (TLState) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.NewMessages, bw);
      ObjectUtils.SerializeObject((object) this.NewEncryptedMessages, bw);
      ObjectUtils.SerializeObject((object) this.OtherUpdates, bw);
      ObjectUtils.SerializeObject((object) this.Chats, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
      ObjectUtils.SerializeObject((object) this.State, bw);
    }
  }
}
