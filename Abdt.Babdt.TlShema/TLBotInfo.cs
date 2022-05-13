using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1729618630)]
  public class TLBotInfo : TLObject
  {
    public override int Constructor => -1729618630;

    public int UserId { get; set; }

    public string Description { get; set; }

    public TLVector<TLBotCommand> Commands { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = br.ReadInt32();
      this.Description = StringUtil.Deserialize(br);
      this.Commands = ObjectUtils.DeserializeVector<TLBotCommand>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.UserId);
      StringUtil.Serialize(this.Description, bw);
      ObjectUtils.SerializeObject((object) this.Commands, bw);
    }
  }
}
