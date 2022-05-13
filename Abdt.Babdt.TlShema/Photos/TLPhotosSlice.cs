using System.IO;

namespace Abdt.Babdt.TlShema.Photos
{
  [TLObject(352657236)]
  public class TLPhotosSlice : TLAbsPhotos
  {
    public override int Constructor => 352657236;

    public int Count { get; set; }

    public TLVector<TLAbsPhoto> Photos { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Count = br.ReadInt32();
      this.Photos = ObjectUtils.DeserializeVector<TLAbsPhoto>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Count);
      ObjectUtils.SerializeObject((object) this.Photos, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
