using System.IO;

namespace Abdt.Babdt.TlShema.Contacts
{
  [TLObject(-1878523231)]
  public class TLBlockedSlice : TLAbsBlocked
  {
    public override int Constructor => -1878523231;

    public int Count { get; set; }

    public TLVector<TLContactBlocked> Blocked { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Count = br.ReadInt32();
      this.Blocked = ObjectUtils.DeserializeVector<TLContactBlocked>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Count);
      ObjectUtils.SerializeObject((object) this.Blocked, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
