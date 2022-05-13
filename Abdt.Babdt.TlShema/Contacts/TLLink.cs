using System.IO;

namespace Abdt.Babdt.TlShema.Contacts
{
  [TLObject(986597452)]
  public class TLLink : TLObject
  {
    public override int Constructor => 986597452;

    public TLAbsContactLink MyLink { get; set; }

    public TLAbsContactLink ForeignLink { get; set; }

    public TLAbsUser User { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.MyLink = (TLAbsContactLink) ObjectUtils.DeserializeObject(br);
      this.ForeignLink = (TLAbsContactLink) ObjectUtils.DeserializeObject(br);
      this.User = (TLAbsUser) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.MyLink, bw);
      ObjectUtils.SerializeObject((object) this.ForeignLink, bw);
      ObjectUtils.SerializeObject((object) this.User, bw);
    }
  }
}
