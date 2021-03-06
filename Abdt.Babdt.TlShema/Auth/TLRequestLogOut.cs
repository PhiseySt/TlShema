using System.IO;

namespace Abdt.Babdt.TlShema.Auth
{
  [TLObject(1461180992)]
  public class TLRequestLogOut : TLMethod
  {
    public override int Constructor => 1461180992;

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
