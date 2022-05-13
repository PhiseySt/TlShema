using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1264392051)]
  public class TLUpdateEncryption : TLAbsUpdate
  {
    public override int Constructor => -1264392051;

    public TLAbsEncryptedChat Chat { get; set; }

    public int Date { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Chat = (TLAbsEncryptedChat) ObjectUtils.DeserializeObject(br);
      this.Date = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Chat, bw);
      bw.Write(this.Date);
    }
  }
}
