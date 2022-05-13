using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1344716869)]
  public class TLKeyboardButtonBuy : TLAbsKeyboardButton
  {
    public override int Constructor => -1344716869;

    public string Text { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Text = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Text, bw);
    }
  }
}
