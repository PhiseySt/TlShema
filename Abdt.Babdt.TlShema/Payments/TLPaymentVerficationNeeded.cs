using System.IO;

namespace Abdt.Babdt.TlShema.Payments
{
  [TLObject(1800845601)]
  public class TLPaymentVerficationNeeded : TLAbsPaymentResult
  {
    public override int Constructor => 1800845601;

    public string Url { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Url = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Url, bw);
    }
  }
}
