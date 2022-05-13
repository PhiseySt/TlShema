using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-84416311)]
  public class TLPhoneCallDiscardReasonBusy : TLAbsPhoneCallDiscardReason
  {
    public override int Constructor => -84416311;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
