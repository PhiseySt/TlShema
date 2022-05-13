using System.IO;

namespace Abdt.Babdt.TlShema.Payments
{
  [TLObject(-1601001088)]
  public class TLRequestGetPaymentReceipt : TLMethod
  {
    public override int Constructor => -1601001088;

    public int MsgId { get; set; }

    public TLPaymentReceipt Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.MsgId = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.MsgId);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLPaymentReceipt) ObjectUtils.DeserializeObject(br);
  }
}
