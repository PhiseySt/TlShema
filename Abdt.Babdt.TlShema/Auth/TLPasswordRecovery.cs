using System.IO;

namespace Abdt.Babdt.TlShema.Auth
{
  [TLObject(326715557)]
  public class TLPasswordRecovery : TLObject
  {
    public override int Constructor => 326715557;

    public string EmailPattern { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.EmailPattern = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.EmailPattern, bw);
    }
  }
}
