using System.IO;

namespace Abdt.Babdt.TlShema.Updates
{
  [TLObject(-304838614)]
  public class TLRequestGetState : TLMethod
  {
    public override int Constructor => -304838614;

    public TLState Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLState) ObjectUtils.DeserializeObject(br);
  }
}
