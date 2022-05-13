using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(125178264)]
  public class TLUpdateChatParticipants : TLAbsUpdate
  {
    public override int Constructor => 125178264;

    public TLAbsChatParticipants Participants { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Participants = (TLAbsChatParticipants) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Participants, bw);
    }
  }
}
