using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-368917890)]
  public class TLPaymentCharge : TLObject
  {
    public override int Constructor => -368917890;

    public string Id { get; set; }

    public string ProviderChargeId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = StringUtil.Deserialize(br);
      this.ProviderChargeId = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Id, bw);
      StringUtil.Serialize(this.ProviderChargeId, bw);
    }
  }
}
