using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(-484392616)]
  public class TLRequestGetAuthorizations : TLMethod
  {
    public override int Constructor => -484392616;

    public TLAuthorizations Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAuthorizations) ObjectUtils.DeserializeObject(br);
  }
}
