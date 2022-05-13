using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(70813275)]
  public class TLInputStickeredMediaDocument : TLAbsInputStickeredMedia
  {
    public override int Constructor => 70813275;

    public TLAbsInputDocument Id { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Id = (TLAbsInputDocument) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }
  }
}
