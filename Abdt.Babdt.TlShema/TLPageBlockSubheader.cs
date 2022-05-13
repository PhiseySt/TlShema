using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-248793375)]
  public class TLPageBlockSubheader : TLAbsPageBlock
  {
    public override int Constructor => -248793375;

    public TLAbsRichText Text { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Text = (TLAbsRichText) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Text, bw);
    }
  }
}
