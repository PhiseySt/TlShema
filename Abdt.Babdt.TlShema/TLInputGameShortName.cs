using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1020139510)]
  public class TLInputGameShortName : TLAbsInputGame
  {
    public override int Constructor => -1020139510;

    public TLAbsInputUser BotId { get; set; }

    public string ShortName { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.BotId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.ShortName = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.BotId, bw);
      StringUtil.Serialize(this.ShortName, bw);
    }
  }
}
