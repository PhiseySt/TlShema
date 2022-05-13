using System.IO;
using Abdt.Babdt.TlShema.Messages;

namespace Abdt.Babdt.TlShema.Channels
{
  [TLObject(-2067661490)]
  public class TLRequestDeleteMessages : TLMethod
  {
    public override int Constructor => -2067661490;

    public TLAbsInputChannel Channel { get; set; }

    public TLVector<int> Id { get; set; }

    public TLAffectedMessages Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Channel = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);
      this.Id = ObjectUtils.DeserializeVector<int>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAffectedMessages) ObjectUtils.DeserializeObject(br);
  }
}
