using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(286776671)]
  public class TLGeoPointEmpty : TLAbsGeoPoint
  {
    public override int Constructor => 286776671;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
