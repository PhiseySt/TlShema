using System.IO;

namespace Abdt.Babdt.TlShema.Auth
{
  [TLObject(-661144474)]
  public class TLRequestRequestPasswordRecovery : TLMethod
  {
    public override int Constructor => -661144474;

    public TLPasswordRecovery Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLPasswordRecovery) ObjectUtils.DeserializeObject(br);
  }
}
