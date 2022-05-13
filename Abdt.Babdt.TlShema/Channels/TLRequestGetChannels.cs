using System.IO;
using Abdt.Babdt.TlShema.Messages;

namespace Abdt.Babdt.TlShema.Channels
{
  [TLObject(176122811)]
  public class TLRequestGetChannels : TLMethod
  {
    public override int Constructor => 176122811;

    public TLVector<TLAbsInputChannel> Id { get; set; }

    public TLAbsChats Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Id = ObjectUtils.DeserializeVector<TLAbsInputChannel>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsChats) ObjectUtils.DeserializeObject(br);
  }
}
