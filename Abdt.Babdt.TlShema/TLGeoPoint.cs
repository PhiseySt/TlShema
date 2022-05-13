using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(541710092)]
  public class TLGeoPoint : TLAbsGeoPoint
  {
    public override int Constructor => 541710092;

    public double Long { get; set; }

    public double Lat { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Long = br.ReadDouble();
      this.Lat = br.ReadDouble();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Long);
      bw.Write(this.Lat);
    }
  }
}
