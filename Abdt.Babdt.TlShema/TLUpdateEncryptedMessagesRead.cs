using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(956179895)]
  public class TLUpdateEncryptedMessagesRead : TLAbsUpdate
  {
    public override int Constructor => 956179895;

    public int ChatId { get; set; }

    public int MaxDate { get; set; }

    public int Date { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ChatId = br.ReadInt32();
      this.MaxDate = br.ReadInt32();
      this.Date = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChatId);
      bw.Write(this.MaxDate);
      bw.Write(this.Date);
    }
  }
}
