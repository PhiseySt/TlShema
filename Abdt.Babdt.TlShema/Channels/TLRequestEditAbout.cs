using System.IO;

namespace Abdt.Babdt.TlShema.Channels
{
  [TLObject(333610782)]
  public class TLRequestEditAbout : TLMethod
  {
    public override int Constructor => 333610782;

    public TLAbsInputChannel Channel { get; set; }

    public string About { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Channel = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);
      this.About = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
      StringUtil.Serialize(this.About, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
