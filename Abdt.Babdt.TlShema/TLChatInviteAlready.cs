using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1516793212)]
  public class TLChatInviteAlready : TLAbsChatInvite
  {
    public override int Constructor => 1516793212;

    public TLAbsChat Chat { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Chat = (TLAbsChat) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Chat, bw);
    }
  }
}
