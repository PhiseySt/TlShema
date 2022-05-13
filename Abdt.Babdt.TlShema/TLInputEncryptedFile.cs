using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1511503333)]
  public class TLInputEncryptedFile : TLAbsInputEncryptedFile
  {
    public override int Constructor => 1511503333;

    public long Id { get; set; }

    public long AccessHash { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt64();
      this.AccessHash = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      bw.Write(this.AccessHash);
    }
  }
}
