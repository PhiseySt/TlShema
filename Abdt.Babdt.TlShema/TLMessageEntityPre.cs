using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1938967520)]
  public class TLMessageEntityPre : TLAbsMessageEntity
  {
    public override int Constructor => 1938967520;

    public int Offset { get; set; }

    public int Length { get; set; }

    public string Language { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Offset = br.ReadInt32();
      this.Length = br.ReadInt32();
      this.Language = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Offset);
      bw.Write(this.Length);
      StringUtil.Serialize(this.Language, bw);
    }
  }
}
