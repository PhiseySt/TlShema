using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(1558317424)]
  public class TLRecentStickers : TLAbsRecentStickers
  {
    public override int Constructor => 1558317424;

    public int Hash { get; set; }

    public TLVector<TLAbsDocument> Stickers { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Hash = br.ReadInt32();
      this.Stickers = ObjectUtils.DeserializeVector<TLAbsDocument>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Hash);
      ObjectUtils.SerializeObject((object) this.Stickers, bw);
    }
  }
}
