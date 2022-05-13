using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-203411800)]
  public class TLMessageMediaDocument : TLAbsMessageMedia
  {
    public override int Constructor => -203411800;

    public TLAbsDocument Document { get; set; }

    public string Caption { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Document = (TLAbsDocument) ObjectUtils.DeserializeObject(br);
      this.Caption = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Document, bw);
      StringUtil.Serialize(this.Caption, bw);
    }
  }
}
