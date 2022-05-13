using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-326379039)]
  public class TLRequestToggleChatAdmins : TLMethod
  {
    public override int Constructor => -326379039;

    public int ChatId { get; set; }

    public bool Enabled { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ChatId = br.ReadInt32();
      this.Enabled = BoolUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChatId);
      BoolUtil.Serialize(this.Enabled, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
