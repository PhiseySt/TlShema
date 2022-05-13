using System.IO;

namespace Abdt.Babdt.TlShema.Auth
{
  [TLObject(-1616179942)]
  public class TLRequestResetAuthorizations : TLMethod
  {
    public override int Constructor => -1616179942;

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
