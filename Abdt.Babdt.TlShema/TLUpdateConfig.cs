using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1574314746)]
  public class TLUpdateConfig : TLAbsUpdate
  {
    public override int Constructor => -1574314746;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
