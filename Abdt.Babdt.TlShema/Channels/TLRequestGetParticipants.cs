using System.IO;

namespace Abdt.Babdt.TlShema.Channels
{
  [TLObject(618237842)]
  public class TLRequestGetParticipants : TLMethod
  {
    public override int Constructor => 618237842;

    public TLAbsInputChannel Channel { get; set; }

    public TLAbsChannelParticipantsFilter Filter { get; set; }

    public int Offset { get; set; }

    public int Limit { get; set; }

    public TLChannelParticipants Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Channel = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);
      this.Filter = (TLAbsChannelParticipantsFilter) ObjectUtils.DeserializeObject(br);
      this.Offset = br.ReadInt32();
      this.Limit = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
      ObjectUtils.SerializeObject((object) this.Filter, bw);
      bw.Write(this.Offset);
      bw.Write(this.Limit);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLChannelParticipants) ObjectUtils.DeserializeObject(br);
  }
}
