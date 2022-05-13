using System.IO;

namespace Abdt.Babdt.TlShema.Help
{
  [TLObject(415997816)]
  public class TLInviteText : TLObject
  {
    public override int Constructor => 415997816;

    public string Message { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Message = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Message, bw);
    }
  }
}
