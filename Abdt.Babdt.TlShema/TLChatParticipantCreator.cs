using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-636267638)]
  public class TLChatParticipantCreator : TLAbsChatParticipant
  {
    public override int Constructor => -636267638;

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
