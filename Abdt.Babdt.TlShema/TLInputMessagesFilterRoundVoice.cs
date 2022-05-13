using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(2054952868)]
  public class TLInputMessagesFilterRoundVoice : TLAbsMessagesFilter
  {
    public override int Constructor => 2054952868;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
