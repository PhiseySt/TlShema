using System.IO;

namespace Abdt.Babdt.TlShema.Upload
{
  [TLObject(-1291540959)]
  public class TLRequestSaveFilePart : TLMethod
  {
    public override int Constructor => -1291540959;

    public long FileId { get; set; }

    public int FilePart { get; set; }

    public byte[] Bytes { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.FileId = br.ReadInt64();
      this.FilePart = br.ReadInt32();
      this.Bytes = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.FileId);
      bw.Write(this.FilePart);
      BytesUtil.Serialize(this.Bytes, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
