using System.IO;

namespace Abdt.Babdt.TlShema.Upload
{
  [TLObject(536919235)]
  public class TLRequestGetCdnFile : TLMethod
  {
    public override int Constructor => 536919235;

    public byte[] FileToken { get; set; }

    public int Offset { get; set; }

    public int Limit { get; set; }

    public TLAbsCdnFile Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.FileToken = BytesUtil.Deserialize(br);
      this.Offset = br.ReadInt32();
      this.Limit = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BytesUtil.Serialize(this.FileToken, bw);
      bw.Write(this.Offset);
      bw.Write(this.Limit);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsCdnFile) ObjectUtils.DeserializeObject(br);
  }
}
