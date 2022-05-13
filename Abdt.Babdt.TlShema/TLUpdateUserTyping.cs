using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1548249383)]
  public class TLUpdateUserTyping : TLAbsUpdate
  {
    public override int Constructor => 1548249383;

    public int UserId { get; set; }

    public TLAbsSendMessageAction Action { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = br.ReadInt32();
      this.Action = (TLAbsSendMessageAction) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.UserId);
      ObjectUtils.SerializeObject((object) this.Action, bw);
    }
  }
}
