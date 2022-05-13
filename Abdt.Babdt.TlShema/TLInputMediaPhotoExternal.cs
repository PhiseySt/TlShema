using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1252045032)]
  public class TLInputMediaPhotoExternal : TLAbsInputMedia
  {
    public override int Constructor => -1252045032;

    public string Url { get; set; }

    public string Caption { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Url = StringUtil.Deserialize(br);
      this.Caption = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Url, bw);
      StringUtil.Serialize(this.Caption, bw);
    }
  }
}
