using System.IO;

namespace Abdt.Babdt.TlShema.Auth
{
  [TLObject(577556219)]
  public class TLCodeTypeFlashCall : TLAbsCodeType
  {
    public override int Constructor => 577556219;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
