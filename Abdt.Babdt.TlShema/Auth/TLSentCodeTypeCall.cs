using System.IO;

namespace Abdt.Babdt.TlShema.Auth
{
  [TLObject(1398007207)]
  public class TLSentCodeTypeCall : TLAbsSentCodeType
  {
    public override int Constructor => 1398007207;

    public int Length { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => Length = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Length);
    }
  }
}
