using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(-614138572)]
  public class TLTmpPassword : TLObject
  {
    public override int Constructor => -614138572;

    public byte[] TmpPassword { get; set; }

    public int ValidUntil { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.TmpPassword = BytesUtil.Deserialize(br);
      this.ValidUntil = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BytesUtil.Serialize(this.TmpPassword, bw);
      bw.Write(this.ValidUntil);
    }
  }
}
