using System.IO;
using Abdt.Babdt.TlShema.Messages;

namespace Abdt.Babdt.TlShema.Channels
{
  [TLObject(-787622117)]
  public class TLRequestDeleteUserHistory : TLMethod
  {
    public override int Constructor => -787622117;

    public TLAbsInputChannel Channel { get; set; }

    public TLAbsInputUser UserId { get; set; }

    public TLAffectedHistory Response { get; set; }

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

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAffectedHistory) ObjectUtils.DeserializeObject(br);
  }
}
