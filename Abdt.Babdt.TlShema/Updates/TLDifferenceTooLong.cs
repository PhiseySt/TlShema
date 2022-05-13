using System.IO;

namespace Abdt.Babdt.TlShema.Updates
{
  [TLObject(1258196845)]
  public class TLDifferenceTooLong : TLAbsDifference
  {
    public override int Constructor => 1258196845;

    public int Pts { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Pts = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Pts);
    }
  }
}
