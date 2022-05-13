using System.IO;

namespace Abdt.Babdt.TlShema.Payments
{
  [TLObject(-1712285883)]
  public class TLRequestGetPaymentForm : TLMethod
  {
    public override int Constructor => -1712285883;

    public int MsgId { get; set; }

    public TLPaymentForm Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.MsgId = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.MsgId);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLPaymentForm) ObjectUtils.DeserializeObject(br);
  }
}
