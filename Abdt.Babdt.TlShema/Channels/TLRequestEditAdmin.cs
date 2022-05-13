using System.IO;

namespace Abdt.Babdt.TlShema.Channels
{
  [TLObject(-344583728)]
  public class TLRequestEditAdmin : TLMethod
  {
    public override int Constructor => -344583728;

    public TLAbsInputChannel Channel { get; set; }

    public TLAbsInputUser UserId { get; set; }

    public TLAbsChannelParticipantRole Role { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Channel = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.Role = (TLAbsChannelParticipantRole) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
      ObjectUtils.SerializeObject((object) this.Role, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
