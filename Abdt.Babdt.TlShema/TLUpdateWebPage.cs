using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(2139689491)]
  public class TLUpdateWebPage : TLAbsUpdate
  {
    public override int Constructor => 2139689491;

    public TLAbsWebPage Webpage { get; set; }

    public int Pts { get; set; }

    public int PtsCount { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Webpage = (TLAbsWebPage) ObjectUtils.DeserializeObject(br);
      this.Pts = br.ReadInt32();
      this.PtsCount = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Webpage, bw);
      bw.Write(this.Pts);
      bw.Write(this.PtsCount);
    }
  }
}
