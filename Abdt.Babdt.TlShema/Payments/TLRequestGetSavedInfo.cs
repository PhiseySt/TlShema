using System.IO;

namespace Abdt.Babdt.TlShema.Payments
{
  [TLObject(578650699)]
  public class TLRequestGetSavedInfo : TLMethod
  {
    public override int Constructor => 578650699;

    public TLSavedInfo Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLSavedInfo) ObjectUtils.DeserializeObject(br);
  }
}
