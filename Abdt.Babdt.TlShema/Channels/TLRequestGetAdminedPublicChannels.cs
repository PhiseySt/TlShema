using System.IO;
using Abdt.Babdt.TlShema.Messages;

namespace Abdt.Babdt.TlShema.Channels
{
  [TLObject(-1920105769)]
  public class TLRequestGetAdminedPublicChannels : TLMethod
  {
    public override int Constructor => -1920105769;

    public TLAbsChats Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsChats) ObjectUtils.DeserializeObject(br);
  }
}
