using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1008755359)]
  public class TLInlineBotSwitchPM : TLObject
  {
    public override int Constructor => 1008755359;

    public string Text { get; set; }

    public string StartParam { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Text = StringUtil.Deserialize(br);
      this.StartParam = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Text, bw);
      StringUtil.Serialize(this.StartParam, bw);
    }
  }
}
