using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1471006352)]
  public class TLPhoneCallDiscardReasonHangup : TLAbsPhoneCallDiscardReason
  {
    public override int Constructor => 1471006352;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
