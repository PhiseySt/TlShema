using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(480546647)]
  public class TLInputChatPhotoEmpty : TLAbsInputChatPhoto
  {
    public override int Constructor => 480546647;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
