using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(-1212732749)]
  public class TLPasswordSettings : TLObject
  {
    public override int Constructor => -1212732749;

    public string Email { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Email = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Email, bw);
    }
  }
}
