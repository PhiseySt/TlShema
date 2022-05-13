using System.IO;

namespace Abdt.Babdt.TlShema.Channels
{
  [TLObject(141781513)]
  public class TLRequestGetFullChannel : TLMethod
  {
    public override int Constructor => 141781513;

    public TLAbsInputChannel Channel { get; set; }

    public global::Abdt.Babdt.TlShema.Messages.TLChatFull Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Channel = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (global::Abdt.Babdt.TlShema.Messages.TLChatFull) ObjectUtils.DeserializeObject(br);
  }
}
