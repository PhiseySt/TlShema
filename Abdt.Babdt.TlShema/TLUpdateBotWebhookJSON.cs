using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-2095595325)]
  public class TLUpdateBotWebhookJSON : TLAbsUpdate
  {
    public override int Constructor => -2095595325;

    public TLDataJSON Data { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Data = (TLDataJSON) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Data, bw);
    }
  }
}
