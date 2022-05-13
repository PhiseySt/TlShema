using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-162681021)]
  public class TLRequestRequestEncryption : TLMethod
  {
    public override int Constructor => -162681021;

    public TLAbsInputUser UserId { get; set; }

    public int RandomId { get; set; }

    public byte[] GA { get; set; }

    public TLAbsEncryptedChat Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.RandomId = br.ReadInt32();
      this.GA = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
      bw.Write(this.RandomId);
      BytesUtil.Serialize(this.GA, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsEncryptedChat) ObjectUtils.DeserializeObject(br);
  }
}
