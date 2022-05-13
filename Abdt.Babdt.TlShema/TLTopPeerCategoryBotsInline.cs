using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(344356834)]
  public class TLTopPeerCategoryBotsInline : TLAbsTopPeerCategory
  {
    public override int Constructor => 344356834;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
