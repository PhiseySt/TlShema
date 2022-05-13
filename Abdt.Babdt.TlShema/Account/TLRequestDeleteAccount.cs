using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(1099779595)]
  public class TLRequestDeleteAccount : TLMethod
  {
    public override int Constructor => 1099779595;

    public string Reason { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Reason = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Reason, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
