using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(483901197)]
  public class TLInputPhotoEmpty : TLAbsInputPhoto
  {
    public override int Constructor => 483901197;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
