using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(1443858741)]
  public class TLSentEncryptedMessage : TLAbsSentEncryptedMessage
  {
    public override int Constructor => 1443858741;

    public int Date { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Date = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Date);
    }
  }
}
