using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1036301552)]
  public class TLRequestInvokeAfterMsgs : TLMethod
  {
    public override int Constructor => 1036301552;

    public TLVector<long> MsgIds { get; set; }

    public TLObject Query { get; set; }

    public TLObject Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.MsgIds = ObjectUtils.DeserializeVector<long>(br);
      this.Query = (TLObject) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.MsgIds, bw);
      ObjectUtils.SerializeObject((object) this.Query, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLObject) ObjectUtils.DeserializeObject(br);
  }
}
