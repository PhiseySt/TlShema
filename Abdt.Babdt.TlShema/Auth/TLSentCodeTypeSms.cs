using System.IO;

namespace Abdt.Babdt.TlShema.Auth
{
  [TLObject(-1073693790)]
  public class TLSentCodeTypeSms : TLAbsSentCodeType
  {
    public override int Constructor => -1073693790;

    public int Length { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Length = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Length);
    }
  }
}
