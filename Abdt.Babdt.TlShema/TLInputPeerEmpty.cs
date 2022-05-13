using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(2134579434)]
  public class TLInputPeerEmpty : TLAbsInputPeer
  {
    public override int Constructor => 2134579434;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
