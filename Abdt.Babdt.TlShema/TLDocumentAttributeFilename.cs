using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(358154344)]
  public class TLDocumentAttributeFilename : TLAbsDocumentAttribute
  {
    public override int Constructor => 358154344;

    public string FileName { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.FileName = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.FileName, bw);
    }
  }
}
