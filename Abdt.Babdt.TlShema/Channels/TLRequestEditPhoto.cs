using System.IO;

namespace Abdt.Babdt.TlShema.Channels
{
  [TLObject(-248621111)]
  public class TLRequestEditPhoto : TLMethod
  {
    public override int Constructor => -248621111;

    public TLAbsInputChannel Channel { get; set; }

    public TLAbsInputChatPhoto Photo { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Channel = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);
      this.Photo = (TLAbsInputChatPhoto) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
      ObjectUtils.SerializeObject((object) this.Photo, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
