using System.IO;

namespace Abdt.Babdt.TlShema.Payments
{
  [TLObject(1314881805)]
  public class TLPaymentResult : TLAbsPaymentResult
  {
    public override int Constructor => 1314881805;

    public TLAbsUpdates Updates { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Updates = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Updates, bw);
    }
  }
}
