using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1957577280)]
  public class TLUpdates : TLAbsUpdates
  {
    public override int Constructor => 1957577280;

    public TLVector<TLAbsUpdate> Updates { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public TLVector<TLAbsChat> Chats { get; set; }

    public int Date { get; set; }

    public int Seq { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Updates = ObjectUtils.DeserializeVector<TLAbsUpdate>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
      this.Chats = ObjectUtils.DeserializeVector<TLAbsChat>(br);
      this.Date = br.ReadInt32();
      this.Seq = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Updates, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
      ObjectUtils.SerializeObject((object) this.Chats, bw);
      bw.Write(this.Date);
      bw.Write(this.Seq);
    }
  }
}
