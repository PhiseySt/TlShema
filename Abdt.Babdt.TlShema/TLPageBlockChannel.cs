using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-283684427)]
  public class TLPageBlockChannel : TLAbsPageBlock
  {
    public override int Constructor => -283684427;

    public TLAbsChat Channel { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Channel = (TLAbsChat) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
    }
  }
}
