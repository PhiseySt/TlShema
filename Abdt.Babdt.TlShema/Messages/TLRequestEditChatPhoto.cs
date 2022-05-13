using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-900957736)]
  public class TLRequestEditChatPhoto : TLMethod
  {
    public override int Constructor => -900957736;

    public int ChatId { get; set; }

    public TLAbsInputChatPhoto Photo { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ChatId = br.ReadInt32();
      this.Photo = (TLAbsInputChatPhoto) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChatId);
      ObjectUtils.SerializeObject((object) this.Photo, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
