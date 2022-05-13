using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(655677548)]
  public class TLRequestCheckUsername : TLMethod
  {
    public override int Constructor => 655677548;

    public string Username { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Username = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Username, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
