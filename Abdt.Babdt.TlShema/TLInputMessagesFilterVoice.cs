using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1358283666)]
  public class TLInputMessagesFilterVoice : TLAbsMessagesFilter
  {
    public override int Constructor => 1358283666;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
