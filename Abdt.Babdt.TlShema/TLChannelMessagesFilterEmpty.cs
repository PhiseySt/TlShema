using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1798033689)]
  public class TLChannelMessagesFilterEmpty : TLAbsChannelMessagesFilter
  {
    public override int Constructor => -1798033689;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
