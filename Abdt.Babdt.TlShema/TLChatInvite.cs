using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-613092008)]
  public class TLChatInvite : TLAbsChatInvite
  {
    public override int Constructor => -613092008;

    public int Flags { get; set; }

    public bool Channel { get; set; }

    public bool Broadcast { get; set; }

    public bool Public { get; set; }

    public bool Megagroup { get; set; }

    public string Title { get; set; }

    public TLAbsChatPhoto Photo { get; set; }

    public int ParticipantsCount { get; set; }

    public TLVector<TLAbsUser> Participants { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Channel ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Broadcast ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Public ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.Megagroup ? this.Flags | 8 : this.Flags & -9;
      this.Flags = this.Participants != null ? this.Flags | 16 : this.Flags & -17;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Channel = (uint) (this.Flags & 1) > 0U;
      this.Broadcast = (uint) (this.Flags & 2) > 0U;
      this.Public = (uint) (this.Flags & 4) > 0U;
      this.Megagroup = (uint) (this.Flags & 8) > 0U;
      this.Title = StringUtil.Deserialize(br);
      this.Photo = (TLAbsChatPhoto) ObjectUtils.DeserializeObject(br);
      this.ParticipantsCount = br.ReadInt32();
      if ((this.Flags & 16) != 0)
        this.Participants = ObjectUtils.DeserializeVector<TLAbsUser>(br);
      else
        this.Participants = (TLVector<TLAbsUser>) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      StringUtil.Serialize(this.Title, bw);
      ObjectUtils.SerializeObject((object) this.Photo, bw);
      bw.Write(this.ParticipantsCount);
      if ((this.Flags & 16) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.Participants, bw);
    }
  }
}
