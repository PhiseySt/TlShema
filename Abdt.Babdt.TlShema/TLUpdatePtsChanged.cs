using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(861169551)]
  public class TLUpdatePtsChanged : TLAbsUpdate
  {
    public override int Constructor => 861169551;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
