using System.IO;

namespace Abdt.Babdt.TlShema.Auth
{
  [TLObject(1319464594)]
  public class TLRequestRecoverPassword : TLMethod
  {
    public override int Constructor => 1319464594;

    public string Code { get; set; }

    public TLAuthorization Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Code = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Code, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAuthorization) ObjectUtils.DeserializeObject(br);
  }
}
