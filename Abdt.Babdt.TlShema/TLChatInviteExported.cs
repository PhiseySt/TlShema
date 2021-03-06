using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-64092740)]
  public class TLChatInviteExported : TLAbsExportedChatInvite
  {
    public override int Constructor => -64092740;

    public string Link { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Link = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Link, bw);
    }
  }
}
