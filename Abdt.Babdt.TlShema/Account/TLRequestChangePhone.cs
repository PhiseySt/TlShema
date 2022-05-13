using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(1891839707)]
  public class TLRequestChangePhone : TLMethod
  {
    public override int Constructor => 1891839707;

    public string PhoneNumber { get; set; }

    public string PhoneCodeHash { get; set; }

    public string PhoneCode { get; set; }

    public TLAbsUser Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PhoneNumber = StringUtil.Deserialize(br);
      this.PhoneCodeHash = StringUtil.Deserialize(br);
      this.PhoneCode = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.PhoneNumber, bw);
      StringUtil.Serialize(this.PhoneCodeHash, bw);
      StringUtil.Serialize(this.PhoneCode, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUser) ObjectUtils.DeserializeObject(br);
  }
}
