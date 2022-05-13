using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(94983360)]
  public class TLRequestReceivedMessages : TLMethod
  {
    public override int Constructor => 94983360;

    public int MaxId { get; set; }

    public TLVector<TLReceivedNotifyMessage> Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.MaxId = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.MaxId);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = ObjectUtils.DeserializeVector<TLReceivedNotifyMessage>(br);
  }
}
