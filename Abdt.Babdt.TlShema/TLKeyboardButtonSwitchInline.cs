using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(90744648)]
  public class TLKeyboardButtonSwitchInline : TLAbsKeyboardButton
  {
    public override int Constructor => 90744648;

    public int Flags { get; set; }

    public bool SamePeer { get; set; }

    public string Text { get; set; }

    public string Query { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.SamePeer ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.SamePeer = (uint) (this.Flags & 1) > 0U;
      this.Text = StringUtil.Deserialize(br);
      this.Query = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      StringUtil.Serialize(this.Text, bw);
      StringUtil.Serialize(this.Query, bw);
    }
  }
}
