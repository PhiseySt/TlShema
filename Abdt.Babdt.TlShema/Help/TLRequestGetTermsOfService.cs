using System.IO;

namespace Abdt.Babdt.TlShema.Help
{
  [TLObject(889286899)]
  public class TLRequestGetTermsOfService : TLMethod
  {
    public override int Constructor => 889286899;

    public TLTermsOfService Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLTermsOfService) ObjectUtils.DeserializeObject(br);
  }
}
