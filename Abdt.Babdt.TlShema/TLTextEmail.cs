using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-564523562)]
  public class TLTextEmail : TLAbsRichText
  {
    public override int Constructor => -564523562;

    public TLAbsRichText Text { get; set; }

    public string Email { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Text = (TLAbsRichText) ObjectUtils.DeserializeObject(br);
      this.Email = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Text, bw);
      StringUtil.Serialize(this.Email, bw);
    }
  }
}
