using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1169445179)]
  public class TLDraftMessageEmpty : TLAbsDraftMessage
  {
    public override int Constructor => -1169445179;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
