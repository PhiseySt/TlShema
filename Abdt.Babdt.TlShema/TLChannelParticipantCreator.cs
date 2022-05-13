using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-471670279)]
  public class TLChannelParticipantCreator : TLAbsChannelParticipant
  {
    public override int Constructor => -471670279;

    public int UserId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.UserId = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.UserId);
    }
  }
}
