using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(-612493497)]
  public class TLRequestResetNotifySettings : TLMethod
  {
    public override int Constructor => -612493497;

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
