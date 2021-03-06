using System.IO;

namespace Abdt.Babdt.TlShema.Help
{
  [TLObject(1375900482)]
  public class TLRequestGetCdnConfig : TLMethod
  {
    public override int Constructor => 1375900482;

    public TLCdnConfig Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLCdnConfig) ObjectUtils.DeserializeObject(br);
  }
}
