using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1248893260)]
  public class TLEncryptedFile : TLAbsEncryptedFile
  {
    public override int Constructor => 1248893260;

    public long Id { get; set; }

    public long AccessHash { get; set; }

    public int Size { get; set; }

    public int DcId { get; set; }

    public int KeyFingerprint { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt64();
      this.AccessHash = br.ReadInt64();
      this.Size = br.ReadInt32();
      this.DcId = br.ReadInt32();
      this.KeyFingerprint = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      bw.Write(this.AccessHash);
      bw.Write(this.Size);
      bw.Write(this.DcId);
      bw.Write(this.KeyFingerprint);
    }
  }
}
