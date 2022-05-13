using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-2048646399)]
  public class TLPhoneCallDiscardReasonMissed : TLAbsPhoneCallDiscardReason
  {
    public override int Constructor => -2048646399;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
