using System.IO;

namespace Abdt.Babdt.TlShema.Upload
{
  [TLObject(-290921362)]
  public class TLCdnFileReuploadNeeded : TLAbsCdnFile
  {
    public override int Constructor => -290921362;

    public byte[] RequestToken { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.RequestToken = BytesUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BytesUtil.Serialize(this.RequestToken, bw);
    }
  }
}
