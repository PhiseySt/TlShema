using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1457575028)]
  public class TLMessageMediaGeo : TLAbsMessageMedia
  {
    public override int Constructor => 1457575028;

    public TLAbsGeoPoint Geo { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Geo = (TLAbsGeoPoint) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Geo, bw);
    }
  }
}
