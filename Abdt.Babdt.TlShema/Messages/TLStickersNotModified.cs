using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-244016606)]
  public class TLStickersNotModified : TLAbsStickers
  {
    public override int Constructor => -244016606;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
