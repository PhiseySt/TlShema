using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1080663248)]
  public class TLMessageActionPaymentSent : TLAbsMessageAction
  {
    public override int Constructor => 1080663248;

    public string Currency { get; set; }

    public long TotalAmount { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Currency = StringUtil.Deserialize(br);
      this.TotalAmount = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Currency, bw);
      bw.Write(this.TotalAmount);
    }
  }
}
