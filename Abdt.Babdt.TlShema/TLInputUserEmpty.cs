using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1182234929)]
  public class TLInputUserEmpty : TLAbsInputUser
  {
    public override int Constructor => -1182234929;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
