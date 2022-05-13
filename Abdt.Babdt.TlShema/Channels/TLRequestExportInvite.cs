using System.IO;

namespace Abdt.Babdt.TlShema.Channels
{
  [TLObject(-950663035)]
  public class TLRequestExportInvite : TLMethod
  {
    public override int Constructor => -950663035;

    public TLAbsInputChannel Channel { get; set; }

    public TLAbsExportedChatInvite Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Channel = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsExportedChatInvite) ObjectUtils.DeserializeObject(br);
  }
}
