using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(998448230)]
  public class TLRequestGetFullChat : TLMethod
  {
    public override int Constructor => 998448230;

    public int ChatId { get; set; }

    public TLChatFull Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.ChatId = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChatId);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLChatFull) ObjectUtils.DeserializeObject(br);
  }
}
