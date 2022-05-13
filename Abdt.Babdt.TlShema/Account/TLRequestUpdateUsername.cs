using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(1040964988)]
  public class TLRequestUpdateUsername : TLMethod
  {
    public override int Constructor => 1040964988;

    public string Username { get; set; }

    public TLAbsUser Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Username = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Username, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUser) ObjectUtils.DeserializeObject(br);
  }
}
