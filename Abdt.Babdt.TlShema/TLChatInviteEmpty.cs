using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1776236393)]
  public class TLChatInviteEmpty : TLAbsExportedChatInvite
  {
    public override int Constructor => 1776236393;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
