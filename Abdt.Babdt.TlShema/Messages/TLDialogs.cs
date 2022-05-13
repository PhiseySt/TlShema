using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(364538944)]
  public class TLDialogs : TLAbsDialogs
  {
    public override int Constructor => 364538944;

    public TLVector<TLDialog> Dialogs { get; set; }

    public TLVector<TLAbsMessage> Messages { get; set; }

    public TLVector<TLAbsChat> Chats { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Dialogs = ObjectUtils.DeserializeVector<TLDialog>(br);
      this.Messages = ObjectUtils.DeserializeVector<TLAbsMessage>(br);
      this.Chats = ObjectUtils.DeserializeVector<TLAbsChat>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Dialogs, bw);
      ObjectUtils.SerializeObject((object) this.Messages, bw);
      ObjectUtils.SerializeObject((object) this.Chats, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
