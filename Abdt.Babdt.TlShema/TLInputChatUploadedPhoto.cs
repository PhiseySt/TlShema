using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1837345356)]
  public class TLInputChatUploadedPhoto : TLAbsInputChatPhoto
  {
    public override int Constructor => -1837345356;

    public TLAbsInputFile File { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.File = (TLAbsInputFile) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.File, bw);
    }
  }
}
