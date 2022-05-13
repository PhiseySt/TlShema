using System.IO;

namespace Abdt.Babdt.TlShema.Channels
{
  [TLObject(1450044624)]
  public class TLRequestEditTitle : TLMethod
  {
    public override int Constructor => 1450044624;

    public TLAbsInputChannel Channel { get; set; }

    public string Title { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Channel = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);
      this.Title = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
      StringUtil.Serialize(this.Title, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
