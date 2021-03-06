using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-2106619040)]
  public class TLMessageEntityItalic : TLAbsMessageEntity
  {
    public override int Constructor => -2106619040;

    public int Offset { get; set; }

    public int Length { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Offset = br.ReadInt32();
      this.Length = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Offset);
      bw.Write(this.Length);
    }
  }
}
