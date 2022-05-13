using System.IO;

namespace Abdt.Babdt.TlShema.Channels
{
  [TLObject(527021574)]
  public class TLRequestToggleSignatures : TLMethod
  {
    public override int Constructor => 527021574;

    public TLAbsInputChannel Channel { get; set; }

    public bool Enabled { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Channel = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);
      this.Enabled = BoolUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
      BoolUtil.Serialize(this.Enabled, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
