using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1336154098)]
  public class TLInputBotInlineResultGame : TLAbsInputBotInlineResult
  {
    public override int Constructor => 1336154098;

    public string Id { get; set; }

    public string ShortName { get; set; }

    public TLAbsInputBotInlineMessage SendMessage { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = StringUtil.Deserialize(br);
      this.ShortName = StringUtil.Deserialize(br);
      this.SendMessage = (TLAbsInputBotInlineMessage) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Id, bw);
      StringUtil.Serialize(this.ShortName, bw);
      ObjectUtils.SerializeObject((object) this.SendMessage, bw);
    }
  }
}
