using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(129960444)]
  public class TLUserStatusLastWeek : TLAbsUserStatus
  {
    public override int Constructor => 129960444;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
