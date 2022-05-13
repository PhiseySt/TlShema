using System.IO;

namespace Abdt.Babdt.TlShema.Contacts
{
  [TLObject(-1387117803)]
  public class TLImportedContacts : TLObject
  {
    public override int Constructor => -1387117803;

    public TLVector<TLImportedContact> Imported { get; set; }

    public TLVector<long> RetryContacts { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Imported = ObjectUtils.DeserializeVector<TLImportedContact>(br);
      this.RetryContacts = ObjectUtils.DeserializeVector<long>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Imported, bw);
      ObjectUtils.SerializeObject((object) this.RetryContacts, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
