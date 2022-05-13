using System.IO;

namespace Abdt.Babdt.TlShema.Upload
{
  [TLObject(-1449145777)]
  public class TLCdnFile : TLAbsCdnFile
  {
    public override int Constructor => -1449145777;

    public byte[] Bytes { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Bytes = BytesUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BytesUtil.Serialize(this.Bytes, bw);
    }
  }
}
