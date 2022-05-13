using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(2106086025)]
  public class TLRequestExportChatInvite : TLMethod
  {
    public override int Constructor => 2106086025;

    public int ChatId { get; set; }

    public TLAbsExportedChatInvite Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.ChatId = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChatId);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsExportedChatInvite) ObjectUtils.DeserializeObject(br);
  }
}
