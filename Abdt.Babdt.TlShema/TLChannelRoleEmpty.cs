using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1299865402)]
  public class TLChannelRoleEmpty : TLAbsChannelParticipantRole
  {
    public override int Constructor => -1299865402;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
