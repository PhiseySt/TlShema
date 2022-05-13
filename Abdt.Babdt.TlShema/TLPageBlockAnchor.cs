using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-837994576)]
  public class TLPageBlockAnchor : TLAbsPageBlock
  {
    public override int Constructor => -837994576;

    public string Name { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Name = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Name, bw);
    }
  }
}
