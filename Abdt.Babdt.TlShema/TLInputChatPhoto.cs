using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1991004873)]
  public class TLInputChatPhoto : TLAbsInputChatPhoto
  {
    public override int Constructor => -1991004873;

    public TLAbsInputPhoto Id { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Id = (TLAbsInputPhoto) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }
  }
}
