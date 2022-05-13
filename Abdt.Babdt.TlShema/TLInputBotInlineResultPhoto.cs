using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1462213465)]
  public class TLInputBotInlineResultPhoto : TLAbsInputBotInlineResult
  {
    public override int Constructor => -1462213465;

    public string Id { get; set; }

    public string Type { get; set; }

    public TLAbsInputPhoto Photo { get; set; }

    public TLAbsInputBotInlineMessage SendMessage { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = StringUtil.Deserialize(br);
      this.Type = StringUtil.Deserialize(br);
      this.Photo = (TLAbsInputPhoto) ObjectUtils.DeserializeObject(br);
      this.SendMessage = (TLAbsInputBotInlineMessage) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Id, bw);
      StringUtil.Serialize(this.Type, bw);
      ObjectUtils.SerializeObject((object) this.Photo, bw);
      ObjectUtils.SerializeObject((object) this.SendMessage, bw);
    }
  }
}
