using System.IO;

namespace Abdt.Babdt.TlShema.Channels
{
  [TLObject(-871347913)]
  public class TLRequestReadHistory : TLMethod
  {
    public override int Constructor => -871347913;

    public TLAbsInputChannel Channel { get; set; }

    public int MaxId { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Channel = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);
      this.MaxId = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
      bw.Write(this.MaxId);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
