using System.IO;

namespace Abdt.Babdt.TlShema.Channels
{
  [TLObject(1416484774)]
  public class TLRequestGetParticipant : TLMethod
  {
    public override int Constructor => 1416484774;

    public TLAbsInputChannel Channel { get; set; }

    public TLAbsInputUser UserId { get; set; }

    public TLChannelParticipant Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Channel = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLChannelParticipant) ObjectUtils.DeserializeObject(br);
  }
}
