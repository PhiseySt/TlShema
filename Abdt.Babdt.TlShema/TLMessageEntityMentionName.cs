using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(892193368)]
  public class TLMessageEntityMentionName : TLAbsMessageEntity
  {
    public override int Constructor => 892193368;

    public int Offset { get; set; }

    public int Length { get; set; }

    public int UserId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Offset = br.ReadInt32();
      this.Length = br.ReadInt32();
      this.UserId = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Offset);
      bw.Write(this.Length);
      bw.Write(this.UserId);
    }
  }
}
