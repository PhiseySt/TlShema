using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-860866985)]
  public class TLWallPaper : TLAbsWallPaper
  {
    public override int Constructor => -860866985;

    public int Id { get; set; }

    public string Title { get; set; }

    public TLVector<TLAbsPhotoSize> Sizes { get; set; }

    public int Color { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt32();
      this.Title = StringUtil.Deserialize(br);
      this.Sizes = ObjectUtils.DeserializeVector<TLAbsPhotoSize>(br);
      this.Color = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      StringUtil.Serialize(this.Title, bw);
      ObjectUtils.SerializeObject((object) this.Sizes, bw);
      bw.Write(this.Color);
    }
  }
}
