using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1073230141)]
  public class TLNotifyChats : TLAbsNotifyPeer
  {
    public override int Constructor => -1073230141;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
