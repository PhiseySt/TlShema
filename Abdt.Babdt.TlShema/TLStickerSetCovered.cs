using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1678812626)]
  public class TLStickerSetCovered : TLAbsStickerSetCovered
  {
    public override int Constructor => 1678812626;

    public TLStickerSet Set { get; set; }

    public TLAbsDocument Cover { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Set = (TLStickerSet) ObjectUtils.DeserializeObject(br);
      this.Cover = (TLAbsDocument) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Set, bw);
      ObjectUtils.SerializeObject((object) this.Cover, bw);
    }
  }
}
