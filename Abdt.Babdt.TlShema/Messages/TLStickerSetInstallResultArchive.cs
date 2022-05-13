using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(904138920)]
  public class TLStickerSetInstallResultArchive : TLAbsStickerSetInstallResult
  {
    public override int Constructor => 904138920;

    public TLVector<TLAbsStickerSetCovered> Sets { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Sets = ObjectUtils.DeserializeVector<TLAbsStickerSetCovered>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Sets, bw);
    }
  }
}
