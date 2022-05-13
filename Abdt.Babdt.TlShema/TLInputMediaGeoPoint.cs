using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-104578748)]
  public class TLInputMediaGeoPoint : TLAbsInputMedia
  {
    public override int Constructor => -104578748;

    public TLAbsInputGeoPoint GeoPoint { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.GeoPoint = (TLAbsInputGeoPoint) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.GeoPoint, bw);
    }
  }
}
