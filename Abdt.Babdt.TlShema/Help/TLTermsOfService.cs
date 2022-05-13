using System.IO;

namespace Abdt.Babdt.TlShema.Help
{
  [TLObject(-236044656)]
  public class TLTermsOfService : TLObject
  {
    public override int Constructor => -236044656;

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
