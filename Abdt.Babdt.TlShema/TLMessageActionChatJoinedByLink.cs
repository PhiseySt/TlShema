using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-123931160)]
  public class TLMessageActionChatJoinedByLink : TLAbsMessageAction
  {
    public override int Constructor => -123931160;

    public int InviterId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.InviterId = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.InviterId);
    }
  }
}
