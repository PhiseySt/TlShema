using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1614803355)]
  public class TLInputMessagesFilterVideo : TLAbsMessagesFilter
  {
    public override int Constructor => -1614803355;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
