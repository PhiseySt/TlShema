using System.IO;

namespace Abdt.Babdt.TlShema.Auth
{
  [TLObject(-1425815847)]
  public class TLSentCodeTypeFlashCall : TLAbsSentCodeType
  {
    public override int Constructor => -1425815847;

    public string Pattern { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Pattern = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Pattern, bw);
    }
  }
}
