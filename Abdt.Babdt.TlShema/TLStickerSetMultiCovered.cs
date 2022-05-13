using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(872932635)]
  public class TLStickerSetMultiCovered : TLAbsStickerSetCovered
  {
    public override int Constructor => 872932635;

    public TLStickerSet Set { get; set; }

    public TLVector<TLAbsDocument> Covers { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Set = (TLStickerSet) ObjectUtils.DeserializeObject(br);
      this.Covers = ObjectUtils.DeserializeVector<TLAbsDocument>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Set, bw);
      ObjectUtils.SerializeObject((object) this.Covers, bw);
    }
  }
}
