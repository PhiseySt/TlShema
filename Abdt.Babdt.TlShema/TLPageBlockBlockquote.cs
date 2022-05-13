using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(641563686)]
  public class TLPageBlockBlockquote : TLAbsPageBlock
  {
    public override int Constructor => 641563686;

    public TLAbsRichText Text { get; set; }

    public TLAbsRichText Caption { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Text = (TLAbsRichText) ObjectUtils.DeserializeObject(br);
      this.Caption = (TLAbsRichText) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Text, bw);
      ObjectUtils.SerializeObject((object) this.Caption, bw);
    }
  }
}
