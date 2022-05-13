using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1753886890)]
  public class TLUpdateNewStickerSet : TLAbsUpdate
  {
    public override int Constructor => 1753886890;

    public global::Abdt.Babdt.TlShema.Messages.TLStickerSet Stickerset { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Stickerset = (global::Abdt.Babdt.TlShema.Messages.TLStickerSet) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Stickerset, bw);
    }
  }
}
