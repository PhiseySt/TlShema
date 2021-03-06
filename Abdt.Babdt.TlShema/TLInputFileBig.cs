using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-95482955)]
  public class TLInputFileBig : TLAbsInputFile
  {
    public override int Constructor => -95482955;

    public long Id { get; set; }

    public int Parts { get; set; }

    public string Name { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt64();
      this.Parts = br.ReadInt32();
      this.Name = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      bw.Write(this.Parts);
      StringUtil.Serialize(this.Name, bw);
    }
  }
}
