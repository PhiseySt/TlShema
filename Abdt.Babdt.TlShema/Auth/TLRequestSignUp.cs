using System.IO;

namespace Abdt.Babdt.TlShema.Auth
{
  [TLObject(453408308)]
  public class TLRequestSignUp : TLMethod
  {
    public override int Constructor => 453408308;

    public string PhoneNumber { get; set; }

    public string PhoneCodeHash { get; set; }

    public string PhoneCode { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public TLAuthorization Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PhoneNumber = StringUtil.Deserialize(br);
      this.PhoneCodeHash = StringUtil.Deserialize(br);
      this.PhoneCode = StringUtil.Deserialize(br);
      this.FirstName = StringUtil.Deserialize(br);
      this.LastName = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.PhoneNumber, bw);
      StringUtil.Serialize(this.PhoneCodeHash, bw);
      StringUtil.Serialize(this.PhoneCode, bw);
      StringUtil.Serialize(this.FirstName, bw);
      StringUtil.Serialize(this.LastName, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAuthorization) ObjectUtils.DeserializeObject(br);
  }
}
