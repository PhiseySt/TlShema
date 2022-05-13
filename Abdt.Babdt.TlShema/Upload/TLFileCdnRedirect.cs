using System.IO;

namespace Abdt.Babdt.TlShema.Upload
{
  [TLObject(352864346)]
  public class TLFileCdnRedirect : TLAbsFile
  {
    public override int Constructor => 352864346;

    public int DcId { get; set; }

    public byte[] FileToken { get; set; }

    public byte[] EncryptionKey { get; set; }

    public byte[] EncryptionIv { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.DcId = br.ReadInt32();
      this.FileToken = BytesUtil.Deserialize(br);
      this.EncryptionKey = BytesUtil.Deserialize(br);
      this.EncryptionIv = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.DcId);
      BytesUtil.Serialize(this.FileToken, bw);
      BytesUtil.Serialize(this.EncryptionKey, bw);
      BytesUtil.Serialize(this.EncryptionIv, bw);
    }
  }
}
