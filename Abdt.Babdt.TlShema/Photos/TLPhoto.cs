using System.IO;

namespace Abdt.Babdt.TlShema.Photos
{
  [TLObject(539045032)]
  public class TLPhoto : TLObject
  {
    public override int Constructor => 539045032;

    public TLAbsPhoto Photo { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Photo = (TLAbsPhoto) ObjectUtils.DeserializeObject(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Photo, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
