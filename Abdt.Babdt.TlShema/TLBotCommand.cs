using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1032140601)]
  public class TLBotCommand : TLObject
  {
    public override int Constructor => -1032140601;

    public string Command { get; set; }

    public string Description { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Command = StringUtil.Deserialize(br);
      this.Description = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Command, bw);
      StringUtil.Serialize(this.Description, bw);
    }
  }
}
