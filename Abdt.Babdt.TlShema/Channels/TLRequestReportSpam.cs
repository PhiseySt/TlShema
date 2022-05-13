using System.IO;

namespace Abdt.Babdt.TlShema.Channels
{
  [TLObject(-32999408)]
  public class TLRequestReportSpam : TLMethod
  {
    public override int Constructor => -32999408;

    public TLAbsInputChannel Channel { get; set; }

    public TLAbsInputUser UserId { get; set; }

    public TLVector<int> Id { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Channel = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.Id = ObjectUtils.DeserializeVector<int>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
