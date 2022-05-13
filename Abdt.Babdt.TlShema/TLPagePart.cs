using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1913754556)]
  public class TLPagePart : TLAbsPage
  {
    public override int Constructor => -1913754556;

    public TLVector<TLAbsPageBlock> Blocks { get; set; }

    public TLVector<TLAbsPhoto> Photos { get; set; }

    public TLVector<TLAbsDocument> Videos { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Blocks = ObjectUtils.DeserializeVector<TLAbsPageBlock>(br);
      this.Photos = ObjectUtils.DeserializeVector<TLAbsPhoto>(br);
      this.Videos = ObjectUtils.DeserializeVector<TLAbsDocument>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Blocks, bw);
      ObjectUtils.SerializeObject((object) this.Photos, bw);
      ObjectUtils.SerializeObject((object) this.Videos, bw);
    }
  }
}
