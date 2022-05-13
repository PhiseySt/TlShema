
using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(145955919)]
  public class TLPageBlockCollage : TLAbsPageBlock
  {
    public override int Constructor => 145955919;

    public TLVector<TLAbsPageBlock> Items { get; set; }

    public TLAbsRichText Caption { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Items = ObjectUtils.DeserializeVector<TLAbsPageBlock>(br);
      this.Caption = (TLAbsRichText) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Items, bw);
      ObjectUtils.SerializeObject((object) this.Caption, bw);
    }
  }
}
