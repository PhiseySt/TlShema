using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-878758099)]
  public class TLRequestInvokeAfterMsg : TLMethod
  {
    public override int Constructor => -878758099;

    public long MsgId { get; set; }

    public TLObject Query { get; set; }

    public TLObject Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.MsgId = br.ReadInt64();
      this.Query = (TLObject) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.MsgId);
      ObjectUtils.SerializeObject((object) this.Query, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLObject) ObjectUtils.DeserializeObject(br);
  }
}
