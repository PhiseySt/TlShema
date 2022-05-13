using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-677274263)]
  public class TLPageFull : TLAbsPage
  {
    public override int Constructor => -677274263;

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
