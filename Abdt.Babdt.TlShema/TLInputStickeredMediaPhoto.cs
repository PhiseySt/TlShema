using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1251549527)]
  public class TLInputStickeredMediaPhoto : TLAbsInputStickeredMedia
  {
    public override int Constructor => 1251549527;

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
