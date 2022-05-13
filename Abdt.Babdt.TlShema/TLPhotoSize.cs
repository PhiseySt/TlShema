using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(2009052699)]
  public class TLPhotoSize : TLAbsPhotoSize
  {
    public override int Constructor => 2009052699;

    public string Type { get; set; }

    public TLAbsFileLocation Location { get; set; }

    public int W { get; set; }

    public int H { get; set; }

    public int Size { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Type = StringUtil.Deserialize(br);
      this.Location = (TLAbsFileLocation) ObjectUtils.DeserializeObject(br);
      this.W = br.ReadInt32();
      this.H = br.ReadInt32();
      this.Size = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Type, bw);
      ObjectUtils.SerializeObject((object) this.Location, bw);
      bw.Write(this.W);
      bw.Write(this.H);
      bw.Write(this.Size);
    }
  }
}
