using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(423314455)]
  public class TLInputNotifyUsers : TLAbsInputNotifyPeer
  {
    public override int Constructor => 423314455;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
