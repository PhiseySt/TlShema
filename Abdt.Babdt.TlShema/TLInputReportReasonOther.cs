using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-512463606)]
  public class TLInputReportReasonOther : TLAbsReportReason
  {
    public override int Constructor => -512463606;

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
