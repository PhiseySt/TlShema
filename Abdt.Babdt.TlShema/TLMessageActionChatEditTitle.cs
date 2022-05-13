using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1247687078)]
  public class TLMessageActionChatEditTitle : TLAbsMessageAction
  {
    public override int Constructor => -1247687078;

    public string Title { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Title = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Title, bw);
    }
  }
}
