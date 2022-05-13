using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-2066640507)]
  public class TLAffectedMessages : TLObject
  {
    public override int Constructor => -2066640507;

    public int Pts { get; set; }

    public int PtsCount { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Pts = br.ReadInt32();
      this.PtsCount = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Pts);
      bw.Write(this.PtsCount);
    }
  }
}
