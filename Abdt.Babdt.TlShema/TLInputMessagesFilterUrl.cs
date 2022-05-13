using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(2129714567)]
  public class TLInputMessagesFilterUrl : TLAbsMessagesFilter
  {
    public override int Constructor => 2129714567;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
