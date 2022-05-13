using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-106911223)]
  public class TLRequestAddChatUser : TLMethod
  {
    public override int Constructor => -106911223;

    public int ChatId { get; set; }

    public TLAbsInputUser UserId { get; set; }

    public int FwdLimit { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ChatId = br.ReadInt32();
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.FwdLimit = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChatId);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
      bw.Write(this.FwdLimit);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
