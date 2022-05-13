using System.IO;

namespace Abdt.Babdt.TlShema.Channels
{
  [TLObject(283557164)]
  public class TLRequestCheckUsername : TLMethod
  {
    public override int Constructor => 283557164;

    public TLAbsInputChannel Channel { get; set; }

    public string Username { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Channel = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);
      this.Username = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
      StringUtil.Serialize(this.Username, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
