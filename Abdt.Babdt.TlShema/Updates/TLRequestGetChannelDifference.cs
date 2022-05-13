using System.IO;

namespace Abdt.Babdt.TlShema.Updates
{
  [TLObject(51854712)]
  public class TLRequestGetChannelDifference : TLMethod
  {
    public override int Constructor => 51854712;

    public int Flags { get; set; }

    public bool Force { get; set; }

    public TLAbsInputChannel Channel { get; set; }

    public TLAbsChannelMessagesFilter Filter { get; set; }

    public int Pts { get; set; }

    public int Limit { get; set; }

    public TLAbsChannelDifference Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Force ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Force = (uint) (this.Flags & 1) > 0U;
      this.Channel = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);
      this.Filter = (TLAbsChannelMessagesFilter) ObjectUtils.DeserializeObject(br);
      this.Pts = br.ReadInt32();
      this.Limit = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
      ObjectUtils.SerializeObject((object) this.Filter, bw);
      bw.Write(this.Pts);
      bw.Write(this.Limit);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsChannelDifference) ObjectUtils.DeserializeObject(br);
  }
}
