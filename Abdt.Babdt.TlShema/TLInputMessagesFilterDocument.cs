using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1629621880)]
  public class TLInputMessagesFilterDocument : TLAbsMessagesFilter
  {
    public override int Constructor => -1629621880;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
