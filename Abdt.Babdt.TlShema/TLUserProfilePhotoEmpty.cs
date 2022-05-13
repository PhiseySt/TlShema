using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1326562017)]
  public class TLUserProfilePhotoEmpty : TLAbsUserProfilePhoto
  {
    public override int Constructor => 1326562017;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
