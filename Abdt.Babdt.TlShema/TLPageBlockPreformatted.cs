using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1066346178)]
  public class TLPageBlockPreformatted : TLAbsPageBlock
  {
    public override int Constructor => -1066346178;

    public TLAbsRichText Text { get; set; }

    public string Language { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Text = (TLAbsRichText) ObjectUtils.DeserializeObject(br);
      this.Language = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Text, bw);
      StringUtil.Serialize(this.Language, bw);
    }
  }
}
