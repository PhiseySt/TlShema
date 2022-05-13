using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1906403213)]
  public class TLUpdateDcOptions : TLAbsUpdate
  {
    public override int Constructor => -1906403213;

    public TLVector<TLDcOption> DcOptions { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.DcOptions = ObjectUtils.DeserializeVector<TLDcOption>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.DcOptions, bw);
    }
  }
}
