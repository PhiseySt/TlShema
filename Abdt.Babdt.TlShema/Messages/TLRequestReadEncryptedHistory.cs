using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(2135648522)]
  public class TLRequestReadEncryptedHistory : TLMethod
  {
    public override int Constructor => 2135648522;

    public TLInputEncryptedChat Peer { get; set; }

    public int MaxDate { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLInputEncryptedChat) ObjectUtils.DeserializeObject(br);
      this.MaxDate = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.MaxDate);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
