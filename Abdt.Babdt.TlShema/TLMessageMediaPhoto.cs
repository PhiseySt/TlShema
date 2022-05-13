using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1032643901)]
  public class TLMessageMediaPhoto : TLAbsMessageMedia
  {
    public override int Constructor => 1032643901;

    public TLAbsPhoto Photo { get; set; }

    public string Caption { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Photo = (TLAbsPhoto) ObjectUtils.DeserializeObject(br);
      this.Caption = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Photo, bw);
      StringUtil.Serialize(this.Caption, bw);
    }
  }
}
