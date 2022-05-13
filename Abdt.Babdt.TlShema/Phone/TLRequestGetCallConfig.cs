using System.IO;

namespace Abdt.Babdt.TlShema.Phone
{
  [TLObject(1430593449)]
  public class TLRequestGetCallConfig : TLMethod
  {
    public override int Constructor => 1430593449;

    public TLDataJSON Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLDataJSON) ObjectUtils.DeserializeObject(br);
  }
}
