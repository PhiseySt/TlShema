using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(972174080)]
  public class TLPageBlockCover : TLAbsPageBlock
  {
    public override int Constructor => 972174080;

    public TLAbsPageBlock Cover { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Cover = (TLAbsPageBlock) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Cover, bw);
    }
  }
}
