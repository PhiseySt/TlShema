using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1662091044)]
  public class TLWallPaperSolid : TLAbsWallPaper
  {
    public override int Constructor => 1662091044;

    public int Id { get; set; }

    public string Title { get; set; }

    public int BgColor { get; set; }

    public int Color { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt32();
      this.Title = StringUtil.Deserialize(br);
      this.BgColor = br.ReadInt32();
      this.Color = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      StringUtil.Serialize(this.Title, bw);
      bw.Write(this.BgColor);
      bw.Write(this.Color);
    }
  }
}
