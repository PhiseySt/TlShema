using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1503425638)]
  public class TLMessageActionChatCreate : TLAbsMessageAction
  {
    public override int Constructor => -1503425638;

    public string Title { get; set; }

    public TLVector<int> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Title = StringUtil.Deserialize(br);
      this.Users = ObjectUtils.DeserializeVector<int>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Title, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
