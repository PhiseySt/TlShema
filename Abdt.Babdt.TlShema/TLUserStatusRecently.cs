using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-496024847)]
  public class TLUserStatusRecently : TLAbsUserStatus
  {
    public override int Constructor => -496024847;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
