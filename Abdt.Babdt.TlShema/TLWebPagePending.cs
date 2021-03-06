using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-981018084)]
  public class TLWebPagePending : TLAbsWebPage
  {
    public override int Constructor => -981018084;

    public long Id { get; set; }

    public int Date { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt64();
      this.Date = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      bw.Write(this.Date);
    }
  }
}
