using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(164646985)]
  public class TLUserStatusEmpty : TLAbsUserStatus
  {
    public override int Constructor => 164646985;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
