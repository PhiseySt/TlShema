using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1690108678)]
  public class TLInputEncryptedFileUploaded : TLAbsInputEncryptedFile
  {
    public override int Constructor => 1690108678;

    public long Id { get; set; }

    public int Parts { get; set; }

    public string Md5Checksum { get; set; }

    public int KeyFingerprint { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt64();
      this.Parts = br.ReadInt32();
      this.Md5Checksum = StringUtil.Deserialize(br);
      this.KeyFingerprint = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      bw.Write(this.Parts);
      StringUtil.Serialize(this.Md5Checksum, bw);
      bw.Write(this.KeyFingerprint);
    }
  }
}
