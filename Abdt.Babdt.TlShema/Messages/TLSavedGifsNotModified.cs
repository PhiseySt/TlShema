using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-402498398)]
  public class TLSavedGifsNotModified : TLAbsSavedGifs
  {
    public override int Constructor => -402498398;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
