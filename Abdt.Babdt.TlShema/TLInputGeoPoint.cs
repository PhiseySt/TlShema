using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-206066487)]
  public class TLInputGeoPoint : TLAbsInputGeoPoint
  {
    public override int Constructor => -206066487;

    public double Lat { get; set; }

    public double Long { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Lat = br.ReadDouble();
      this.Long = br.ReadDouble();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Lat);
      bw.Write(this.Long);
    }
  }
}
