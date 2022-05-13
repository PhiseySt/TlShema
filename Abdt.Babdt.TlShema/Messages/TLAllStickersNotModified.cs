using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-395967805)]
  public class TLAllStickersNotModified : TLAbsAllStickers
  {
    public override int Constructor => -395967805;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
