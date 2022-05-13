using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1557277184)]
  public class TLMessageMediaWebPage : TLAbsMessageMedia
  {
    public override int Constructor => -1557277184;

    public TLAbsWebPage Webpage { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Webpage = (TLAbsWebPage) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Webpage, bw);
    }
  }
}
