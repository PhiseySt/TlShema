using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(314359194)]
  public class TLUpdateNewEncryptedMessage : TLAbsUpdate
  {
    public override int Constructor => 314359194;

    public TLAbsEncryptedMessage Message { get; set; }

    public int Qts { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Message = (TLAbsEncryptedMessage) ObjectUtils.DeserializeObject(br);
      this.Qts = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Message, bw);
      bw.Write(this.Qts);
    }
  }
}
