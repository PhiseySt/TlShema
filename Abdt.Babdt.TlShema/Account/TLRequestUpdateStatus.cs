using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(1713919532)]
  public class TLRequestUpdateStatus : TLMethod
  {
    public override int Constructor => 1713919532;

    public bool Offline { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Offline = BoolUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BoolUtil.Serialize(this.Offline, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
