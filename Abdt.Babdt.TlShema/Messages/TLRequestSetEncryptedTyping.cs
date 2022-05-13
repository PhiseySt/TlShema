using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(2031374829)]
  public class TLRequestSetEncryptedTyping : TLMethod
  {
    public override int Constructor => 2031374829;

    public TLInputEncryptedChat Peer { get; set; }

    public bool Typing { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLInputEncryptedChat) ObjectUtils.DeserializeObject(br);
      this.Typing = BoolUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      BoolUtil.Serialize(this.Typing, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
