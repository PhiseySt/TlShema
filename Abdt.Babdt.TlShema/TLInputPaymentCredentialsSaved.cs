using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1056001329)]
  public class TLInputPaymentCredentialsSaved : TLAbsInputPaymentCredentials
  {
    public override int Constructor => -1056001329;

    public string Id { get; set; }

    public byte[] TmpPassword { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = StringUtil.Deserialize(br);
      this.TmpPassword = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Id, bw);
      BytesUtil.Serialize(this.TmpPassword, bw);
    }
  }
}
