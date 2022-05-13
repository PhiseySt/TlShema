using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(629866245)]
  public class TLKeyboardButtonUrl : TLAbsKeyboardButton
  {
    public override int Constructor => 629866245;

    public string Text { get; set; }

    public string Url { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Text = StringUtil.Deserialize(br);
      this.Url = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Text, bw);
      StringUtil.Serialize(this.Url, bw);
    }
  }
}
