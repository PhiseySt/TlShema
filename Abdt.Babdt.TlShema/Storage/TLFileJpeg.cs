using System.IO;

namespace Abdt.Babdt.TlShema.Storage
{
  [TLObject(8322574)]
  public class TLFileJpeg : TLAbsFileType
  {
    public override int Constructor => 8322574;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
