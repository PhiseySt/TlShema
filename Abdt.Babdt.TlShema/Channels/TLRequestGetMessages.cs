using System.IO;
using Abdt.Babdt.TlShema.Messages;

namespace Abdt.Babdt.TlShema.Channels
{
  [TLObject(-1814580409)]
  public class TLRequestGetMessages : TLMethod
  {
    public override int Constructor => -1814580409;

    public TLAbsInputChannel Channel { get; set; }

    public TLVector<int> Id { get; set; }

    public TLAbsMessages Response { get; set; }

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

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsMessages) ObjectUtils.DeserializeObject(br);
  }
}
