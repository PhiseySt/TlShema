using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1576161051)]
  public class TLUpdateDeleteMessages : TLAbsUpdate
  {
    public override int Constructor => -1576161051;

    public TLVector<int> Messages { get; set; }

    public int Pts { get; set; }

    public int PtsCount { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Messages = ObjectUtils.DeserializeVector<int>(br);
      this.Pts = br.ReadInt32();
      this.PtsCount = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Messages, bw);
      bw.Write(this.Pts);
      bw.Write(this.PtsCount);
    }
  }
}
