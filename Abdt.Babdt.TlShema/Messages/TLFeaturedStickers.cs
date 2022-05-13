using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-123893531)]
  public class TLFeaturedStickers : TLAbsFeaturedStickers
  {
    public override int Constructor => -123893531;

    public int Hash { get; set; }

    public TLVector<TLAbsStickerSetCovered> Sets { get; set; }

    public TLVector<long> Unread { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Hash = br.ReadInt32();
      this.Sets = ObjectUtils.DeserializeVector<TLAbsStickerSetCovered>(br);
      this.Unread = ObjectUtils.DeserializeVector<long>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Hash);
      ObjectUtils.SerializeObject((object) this.Sets, bw);
      ObjectUtils.SerializeObject((object) this.Unread, bw);
    }
  }
}
