using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1560655744)]
  public class TLKeyboardButton : TLAbsKeyboardButton
  {
    public override int Constructor => -1560655744;

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
