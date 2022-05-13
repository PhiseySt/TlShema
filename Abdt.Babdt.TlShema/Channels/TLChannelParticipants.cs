using System.IO;

namespace Abdt.Babdt.TlShema.Channels
{
  [TLObject(-177282392)]
  public class TLChannelParticipants : TLObject
  {
    public override int Constructor => -177282392;

    public int Count { get; set; }

    public TLVector<TLAbsChannelParticipant> Participants { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Count = br.ReadInt32();
      this.Participants = ObjectUtils.DeserializeVector<TLAbsChannelParticipant>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Count);
      ObjectUtils.SerializeObject((object) this.Participants, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
