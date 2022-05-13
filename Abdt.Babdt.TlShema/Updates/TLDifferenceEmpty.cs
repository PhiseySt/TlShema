using System.IO;

namespace Abdt.Babdt.TlShema.Updates
{
  [TLObject(1567990072)]
  public class TLDifferenceEmpty : TLAbsDifference
  {
    public override int Constructor => 1567990072;

    public int Date { get; set; }

    public int Seq { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Date = br.ReadInt32();
      this.Seq = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Date);
      bw.Write(this.Seq);
    }
  }
}
