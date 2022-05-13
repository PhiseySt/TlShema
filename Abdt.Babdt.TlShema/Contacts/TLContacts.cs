using System.IO;

namespace Abdt.Babdt.TlShema.Contacts
{
  [TLObject(1871416498)]
  public class TLContacts : TLAbsContacts
  {
    public override int Constructor => 1871416498;

    public TLVector<TLContact> Contacts { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Contacts = ObjectUtils.DeserializeVector<TLContact>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Contacts, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
