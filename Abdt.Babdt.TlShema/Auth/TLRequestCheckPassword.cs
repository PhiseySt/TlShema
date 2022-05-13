using System.IO;

namespace Abdt.Babdt.TlShema.Auth
{
  [TLObject(174260510)]
  public class TLRequestCheckPassword : TLMethod
  {
    public override int Constructor => 174260510;

    public byte[] PasswordHash { get; set; }

    public TLAuthorization Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.PasswordHash = BytesUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BytesUtil.Serialize(this.PasswordHash, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAuthorization) ObjectUtils.DeserializeObject(br);
  }
}
