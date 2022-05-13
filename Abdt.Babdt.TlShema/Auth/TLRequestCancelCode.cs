using System.IO;

namespace Abdt.Babdt.TlShema.Auth
{
  [TLObject(520357240)]
  public class TLRequestCancelCode : TLMethod
  {
    public override int Constructor => 520357240;

    public string PhoneNumber { get; set; }

    public string PhoneCodeHash { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PhoneNumber = StringUtil.Deserialize(br);
      this.PhoneCodeHash = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.PhoneNumber, bw);
      StringUtil.Serialize(this.PhoneCodeHash, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
