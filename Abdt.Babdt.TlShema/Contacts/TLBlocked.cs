using System.IO;

namespace Abdt.Babdt.TlShema.Contacts
{
  [TLObject(471043349)]
  public class TLBlocked : TLAbsBlocked
  {
    public override int Constructor => 471043349;

    public TLVector<TLContactBlocked> Blocked { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Blocked = ObjectUtils.DeserializeVector<TLContactBlocked>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Blocked, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
