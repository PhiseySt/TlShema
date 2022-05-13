using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(852769188)]
  public class TLRequestSendEncryptedService : TLMethod
  {
    public override int Constructor => 852769188;

    public TLInputEncryptedChat Peer { get; set; }

    public long RandomId { get; set; }

    public byte[] Data { get; set; }

    public TLAbsSentEncryptedMessage Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLInputEncryptedChat) ObjectUtils.DeserializeObject(br);
      this.RandomId = br.ReadInt64();
      this.Data = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.RandomId);
      BytesUtil.Serialize(this.Data, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsSentEncryptedMessage) ObjectUtils.DeserializeObject(br);
  }
}
