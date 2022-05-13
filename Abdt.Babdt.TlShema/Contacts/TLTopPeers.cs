using System.IO;

namespace Abdt.Babdt.TlShema.Contacts
{
  [TLObject(1891070632)]
  public class TLTopPeers : TLAbsTopPeers
  {
    public override int Constructor => 1891070632;

    public TLVector<TLTopPeerCategoryPeers> Categories { get; set; }

    public TLVector<TLAbsChat> Chats { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Categories = ObjectUtils.DeserializeVector<TLTopPeerCategoryPeers>(br);
      this.Chats = ObjectUtils.DeserializeVector<TLAbsChat>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Categories, bw);
      ObjectUtils.SerializeObject((object) this.Chats, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
