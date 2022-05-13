using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1990644519)]
  public class TLMessageEntityTextUrl : TLAbsMessageEntity
  {
    public override int Constructor => 1990644519;

    public int Offset { get; set; }

    public int Length { get; set; }

    public string Url { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Offset = br.ReadInt32();
      this.Length = br.ReadInt32();
      this.Url = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Offset);
      bw.Write(this.Length);
      StringUtil.Serialize(this.Url, bw);
    }
  }
}
