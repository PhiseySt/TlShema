using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1268741783)]
  public class TLChannelParticipantsAdmins : TLAbsChannelParticipantsFilter
  {
    public override int Constructor => -1268741783;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
