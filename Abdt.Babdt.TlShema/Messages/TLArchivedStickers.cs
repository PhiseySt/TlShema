using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(1338747336)]
  public class TLArchivedStickers : TLObject
  {
    public override int Constructor => 1338747336;

    public int Count { get; set; }

    public TLVector<TLAbsStickerSetCovered> Sets { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Count = br.ReadInt32();
      this.Sets = ObjectUtils.DeserializeVector<TLAbsStickerSetCovered>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Count);
      ObjectUtils.SerializeObject((object) this.Sets, bw);
    }
  }
}
