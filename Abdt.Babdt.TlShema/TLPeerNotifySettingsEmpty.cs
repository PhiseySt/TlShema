using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1889961234)]
  public class TLPeerNotifySettingsEmpty : TLAbsPeerNotifySettings
  {
    public override int Constructor => 1889961234;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
