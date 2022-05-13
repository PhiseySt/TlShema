using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1061556205)]
  public class TLChatParticipants : TLAbsChatParticipants
  {
    public override int Constructor => 1061556205;

    public int ChatId { get; set; }

    public TLVector<TLAbsChatParticipant> Participants { get; set; }

    public int Version { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ChatId = br.ReadInt32();
      this.Participants = ObjectUtils.DeserializeVector<TLAbsChatParticipant>(br);
      this.Version = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChatId);
      ObjectUtils.SerializeObject((object) this.Participants, bw);
      bw.Write(this.Version);
    }
  }
}
