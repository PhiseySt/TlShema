using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-1802240206)]
  public class TLSentEncryptedFile : TLAbsSentEncryptedMessage
  {
    public override int Constructor => -1802240206;

    public int Date { get; set; }

    public TLAbsEncryptedFile File { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Date = br.ReadInt32();
      this.File = (TLAbsEncryptedFile) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Date);
      ObjectUtils.SerializeObject((object) this.File, bw);
    }
  }
}
