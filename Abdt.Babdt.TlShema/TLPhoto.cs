using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1836524247)]
  public class TLPhoto : TLAbsPhoto
  {
    public override int Constructor => -1836524247;

    public int Flags { get; set; }

    public bool HasStickers { get; set; }

    public long Id { get; set; }

    public long AccessHash { get; set; }

    public int Date { get; set; }

    public TLVector<TLAbsPhotoSize> Sizes { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.HasStickers ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.HasStickers = (uint) (this.Flags & 1) > 0U;
      this.Id = br.ReadInt64();
      this.AccessHash = br.ReadInt64();
      this.Date = br.ReadInt32();
      this.Sizes = ObjectUtils.DeserializeVector<TLAbsPhotoSize>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Id);
      bw.Write(this.AccessHash);
      bw.Write(this.Date);
      ObjectUtils.SerializeObject((object) this.Sizes, bw);
    }
  }
}
