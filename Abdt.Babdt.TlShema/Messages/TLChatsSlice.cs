using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-1663561404)]
  public class TLChatsSlice : TLAbsChats
  {
    public override int Constructor => -1663561404;

    public int Count { get; set; }

    public TLVector<TLAbsChat> Chats { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Count = br.ReadInt32();
      this.Chats = ObjectUtils.DeserializeVector<TLAbsChat>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Count);
      ObjectUtils.SerializeObject((object) this.Chats, bw);
    }
  }
}
