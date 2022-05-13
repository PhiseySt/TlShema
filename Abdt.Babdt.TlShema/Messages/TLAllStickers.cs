using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-302170017)]
  public class TLAllStickers : TLAbsAllStickers
  {
    public override int Constructor => -302170017;

    public int Hash { get; set; }

    public TLVector<global::Abdt.Babdt.TlShema.Messages.TLStickerSet> Sets { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Hash = br.ReadInt32();
      this.Sets = ObjectUtils.DeserializeVector<global::Abdt.Babdt.TlShema.Messages.TLStickerSet>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Hash);
      ObjectUtils.SerializeObject((object) this.Sets, bw);
    }
  }
}
