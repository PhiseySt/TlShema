using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-57668565)]
  public class TLChatParticipantsForbidden : TLAbsChatParticipants
  {
    public override int Constructor => -57668565;

    public int Flags { get; set; }

    public int ChatId { get; set; }

    public TLAbsChatParticipant SelfParticipant { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.SelfParticipant != null ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.ChatId = br.ReadInt32();
      if ((this.Flags & 1) != 0)
        this.SelfParticipant = (TLAbsChatParticipant) ObjectUtils.DeserializeObject(br);
      else
        this.SelfParticipant = (TLAbsChatParticipant) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.ChatId);
      if ((this.Flags & 1) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.SelfParticipant, bw);
    }
  }
}
