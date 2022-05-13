using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(1250046590)]
  public class TLRequestGetTmpPassword : TLMethod
  {
    public override int Constructor => 1250046590;

    public byte[] PasswordHash { get; set; }

    public int Period { get; set; }

    public TLTmpPassword Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PasswordHash = BytesUtil.Deserialize(br);
      this.Period = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BytesUtil.Serialize(this.PasswordHash, bw);
      bw.Write(this.Period);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLTmpPassword) ObjectUtils.DeserializeObject(br);
  }
}
