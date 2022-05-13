using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(524838915)]
  public class TLExportedMessageLink : TLObject
  {
    public override int Constructor => 524838915;

    public string Link { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Link = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Link, bw);
    }
  }
}
