using System.IO;

namespace Abdt.Babdt.TlShema.Help
{
  [TLObject(-1372724842)]
  public class TLRequestGetAppUpdate : TLMethod
  {
    public override int Constructor => -1372724842;

    public TLAbsAppUpdate Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsAppUpdate) ObjectUtils.DeserializeObject(br);
  }
}
