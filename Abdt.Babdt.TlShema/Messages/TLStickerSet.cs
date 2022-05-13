using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-1240849242)]
  public class TLStickerSet : TLObject
  {
    public override int Constructor => -1240849242;

    public TLStickerSet Set { get; set; }

    public TLVector<TLStickerPack> Packs { get; set; }

    public TLVector<TLAbsDocument> Documents { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Set = (TLStickerSet) ObjectUtils.DeserializeObject(br);
      this.Packs = ObjectUtils.DeserializeVector<TLStickerPack>(br);
      this.Documents = ObjectUtils.DeserializeVector<TLAbsDocument>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Set, bw);
      ObjectUtils.SerializeObject((object) this.Packs, bw);
      ObjectUtils.SerializeObject((object) this.Documents, bw);
    }
  }
}
