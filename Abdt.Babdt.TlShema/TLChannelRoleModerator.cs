using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1776756363)]
  public class TLChannelRoleModerator : TLAbsChannelParticipantRole
  {
    public override int Constructor => -1776756363;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
