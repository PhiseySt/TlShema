using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-457104426)]
  public class TLInputGeoPointEmpty : TLAbsInputGeoPoint
  {
    public override int Constructor => -457104426;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
