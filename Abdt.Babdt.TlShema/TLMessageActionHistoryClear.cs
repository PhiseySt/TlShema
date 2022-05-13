using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1615153660)]
  public class TLMessageActionHistoryClear : TLAbsMessageAction
  {
    public override int Constructor => -1615153660;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
