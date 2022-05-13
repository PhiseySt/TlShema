using System.IO;

namespace Abdt.Babdt.TlShema.Payments
{
  [TLObject(1997180532)]
  public class TLRequestValidateRequestedInfo : TLMethod
  {
    public override int Constructor => 1997180532;

    public int Flags { get; set; }

    public bool Save { get; set; }

    public int MsgId { get; set; }

    public TLPaymentRequestedInfo Info { get; set; }

    public TLValidatedRequestedInfo Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Save ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Save = (uint) (this.Flags & 1) > 0U;
      this.MsgId = br.ReadInt32();
      this.Info = (TLPaymentRequestedInfo) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.MsgId);
      ObjectUtils.SerializeObject((object) this.Info, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLValidatedRequestedInfo) ObjectUtils.DeserializeObject(br);
  }
}
