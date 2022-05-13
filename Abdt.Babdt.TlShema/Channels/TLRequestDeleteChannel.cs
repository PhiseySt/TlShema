using System.IO;

namespace Abdt.Babdt.TlShema.Channels
{
  [TLObject(-1072619549)]
  public class TLRequestDeleteChannel : TLMethod
  {
    public override int Constructor => -1072619549;

    public TLAbsInputChannel Channel { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Channel = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
