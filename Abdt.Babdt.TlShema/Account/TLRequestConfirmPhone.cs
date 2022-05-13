using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(1596029123)]
  public class TLRequestConfirmPhone : TLMethod
  {
    public override int Constructor => 1596029123;

    public string PhoneCodeHash { get; set; }

    public string PhoneCode { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PhoneCodeHash = StringUtil.Deserialize(br);
      this.PhoneCode = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.PhoneCodeHash, bw);
      StringUtil.Serialize(this.PhoneCode, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
