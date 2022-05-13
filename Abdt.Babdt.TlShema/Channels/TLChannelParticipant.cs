using System.IO;

namespace Abdt.Babdt.TlShema.Channels
{
  [TLObject(-791039645)]
  public class TLChannelParticipant : TLObject
  {
    public override int Constructor => -791039645;

    public TLAbsChannelParticipant Participant { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Participant = (TLAbsChannelParticipant) ObjectUtils.DeserializeObject(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Participant, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
