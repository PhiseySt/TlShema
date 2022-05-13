using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(1694474197)]
  public class TLChats : TLAbsChats
  {
    public override int Constructor => 1694474197;

    public TLVector<TLAbsChat> Chats { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Chats = ObjectUtils.DeserializeVector<TLAbsChat>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Chats, bw);
    }
  }
}
