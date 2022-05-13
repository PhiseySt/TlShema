using System.IO;

namespace Abdt.Babdt.TlShema.Help
{
  [TLObject(-1663104819)]
  public class TLRequestGetSupport : TLMethod
  {
    public override int Constructor => -1663104819;

    public TLSupport Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLSupport) ObjectUtils.DeserializeObject(br);
  }
}
