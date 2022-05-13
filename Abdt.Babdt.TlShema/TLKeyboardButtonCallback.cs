using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1748655686)]
  public class TLKeyboardButtonCallback : TLAbsKeyboardButton
  {
    public override int Constructor => 1748655686;

    public string Text { get; set; }

    public byte[] Data { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Text = StringUtil.Deserialize(br);
      this.Data = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Text, bw);
      BytesUtil.Serialize(this.Data, bw);
    }
  }
}
