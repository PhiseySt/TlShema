using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(946083368)]
  public class TLStickerSetInstallResultSuccess : TLAbsStickerSetInstallResult
  {
    public override int Constructor => 946083368;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
