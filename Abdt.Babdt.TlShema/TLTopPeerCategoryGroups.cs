using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1122524854)]
  public class TLTopPeerCategoryGroups : TLAbsTopPeerCategory
  {
    public override int Constructor => -1122524854;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
