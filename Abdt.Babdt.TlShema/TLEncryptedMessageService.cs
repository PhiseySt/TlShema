using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(594758406)]
  public class TLEncryptedMessageService : TLAbsEncryptedMessage
  {
    public override int Constructor => 594758406;

    public long RandomId { get; set; }

    public int ChatId { get; set; }

    public int Date { get; set; }

    public byte[] Bytes { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.RandomId = br.ReadInt64();
      this.ChatId = br.ReadInt32();
      this.Date = br.ReadInt32();
      this.Bytes = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.RandomId);
      bw.Write(this.ChatId);
      bw.Write(this.Date);
      BytesUtil.Serialize(this.Bytes, bw);
    }
  }
}
