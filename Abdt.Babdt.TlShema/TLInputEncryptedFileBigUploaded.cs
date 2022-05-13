using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(767652808)]
  public class TLInputEncryptedFileBigUploaded : TLAbsInputEncryptedFile
  {
    public override int Constructor => 767652808;

    public long Id { get; set; }

    public int Parts { get; set; }

    public int KeyFingerprint { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt64();
      this.Parts = br.ReadInt32();
      this.KeyFingerprint = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      bw.Write(this.Parts);
      bw.Write(this.KeyFingerprint);
    }
  }
}
