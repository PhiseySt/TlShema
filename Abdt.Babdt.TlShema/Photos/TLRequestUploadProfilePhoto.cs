using System.IO;

namespace Abdt.Babdt.TlShema.Photos
{
  [TLObject(1328726168)]
  public class TLRequestUploadProfilePhoto : TLMethod
  {
    public override int Constructor => 1328726168;

    public TLAbsInputFile File { get; set; }

    public TLPhoto Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.File = (TLAbsInputFile) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.File, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLPhoto) ObjectUtils.DeserializeObject(br);
  }
}
