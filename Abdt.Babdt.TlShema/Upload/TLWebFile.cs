using System.IO;
using Abdt.Babdt.TlShema.Storage;

namespace Abdt.Babdt.TlShema.Upload
{
  [TLObject(568808380)]
  public class TLWebFile : TLObject
  {
    public override int Constructor => 568808380;

    public int Size { get; set; }

    public string MimeType { get; set; }

    public TLAbsFileType FileType { get; set; }

    public int Mtime { get; set; }

    public byte[] Bytes { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Size = br.ReadInt32();
      this.MimeType = StringUtil.Deserialize(br);
      this.FileType = (TLAbsFileType) ObjectUtils.DeserializeObject(br);
      this.Mtime = br.ReadInt32();
      this.Bytes = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Size);
      StringUtil.Serialize(this.MimeType, bw);
      ObjectUtils.SerializeObject((object) this.FileType, bw);
      bw.Write(this.Mtime);
      BytesUtil.Serialize(this.Bytes, bw);
    }
  }
}
