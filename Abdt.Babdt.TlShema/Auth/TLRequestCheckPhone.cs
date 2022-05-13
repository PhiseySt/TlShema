using System.IO;

namespace Abdt.Babdt.TlShema.Auth
{
  [TLObject(1877286395)]
  public class TLRequestCheckPhone : TLMethod
  {
    public override int Constructor => 1877286395;

    public string PhoneNumber { get; set; }

    public TLCheckedPhone Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.PhoneNumber = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.PhoneNumber, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLCheckedPhone) ObjectUtils.DeserializeObject(br);
  }
}
