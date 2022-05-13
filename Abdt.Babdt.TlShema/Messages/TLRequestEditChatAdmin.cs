using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-1444503762)]
  public class TLRequestEditChatAdmin : TLMethod
  {
    public override int Constructor => -1444503762;

    public int ChatId { get; set; }

    public TLAbsInputUser UserId { get; set; }

    public bool IsAdmin { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ChatId = br.ReadInt32();
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.IsAdmin = BoolUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChatId);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
      BoolUtil.Serialize(this.IsAdmin, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
