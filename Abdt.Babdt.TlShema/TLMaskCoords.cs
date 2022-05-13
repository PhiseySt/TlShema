using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1361650766)]
  public class TLMaskCoords : TLObject
  {
    public override int Constructor => -1361650766;

    public int N { get; set; }

    public double X { get; set; }

    public double Y { get; set; }

    public double Zoom { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.N = br.ReadInt32();
      this.X = br.ReadDouble();
      this.Y = br.ReadDouble();
      this.Zoom = br.ReadDouble();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.N);
      bw.Write(this.X);
      bw.Write(this.Y);
      bw.Write(this.Zoom);
    }
  }
}
