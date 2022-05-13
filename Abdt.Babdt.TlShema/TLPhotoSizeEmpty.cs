using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(236446268)]
  public class TLPhotoSizeEmpty : TLAbsPhotoSize
  {
    public override int Constructor => 236446268;

    public string Type { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Type = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Type, bw);
    }
  }
}
