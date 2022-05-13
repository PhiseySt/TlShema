using System.IO;

namespace Abdt.Babdt.TlShema.Photos
{
  [TLObject(-1916114267)]
  public class TLPhotos : TLAbsPhotos
  {
    public override int Constructor => -1916114267;

    public TLVector<TLAbsPhoto> Photos { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Photos = ObjectUtils.DeserializeVector<TLAbsPhoto>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Photos, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
