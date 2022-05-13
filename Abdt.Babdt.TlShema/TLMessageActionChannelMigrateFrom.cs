using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1336546578)]
  public class TLMessageActionChannelMigrateFrom : TLAbsMessageAction
  {
    public override int Constructor => -1336546578;

    public string Title { get; set; }

    public int ChatId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Title = StringUtil.Deserialize(br);
      this.ChatId = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Title, bw);
      bw.Write(this.ChatId);
    }
  }
}
