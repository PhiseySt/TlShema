using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-527056480)]
  public class TLPhoneCallDiscardReasonDisconnect : TLAbsPhoneCallDiscardReason
  {
    public override int Constructor => -527056480;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
