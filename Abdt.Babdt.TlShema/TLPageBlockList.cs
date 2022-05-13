using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(978896884)]
  public class TLPageBlockList : TLAbsPageBlock
  {
    public override int Constructor => 978896884;

    public bool Ordered { get; set; }

    public TLVector<TLAbsRichText> Items { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Ordered = BoolUtil.Deserialize(br);
      this.Items = ObjectUtils.DeserializeVector<TLAbsRichText>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BoolUtil.Serialize(this.Ordered, bw);
      ObjectUtils.SerializeObject((object) this.Items, bw);
    }
  }
}
