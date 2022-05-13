using System.IO;
using Abdt.Babdt.TlShema.Storage;

namespace Abdt.Babdt.TlShema.Upload
{
  [TLObject(157948117)]
  public class TLFile : TLAbsFile
  {
    public override int Constructor => 157948117;

    public TLAbsFileType Type { get; set; }

    public int Mtime { get; set; }

    public byte[] Bytes { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Type = (TLAbsFileType) ObjectUtils.DeserializeObject(br);
      this.Mtime = br.ReadInt32();
      this.Bytes = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Type, bw);
      bw.Write(this.Mtime);
      BytesUtil.Serialize(this.Bytes, bw);
    }
  }
}
