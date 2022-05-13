using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(873977640)]
  public class TLInputPaymentCredentials : TLAbsInputPaymentCredentials
  {
    public override int Constructor => 873977640;

    public int Flags { get; set; }

    public bool Save { get; set; }

    public TLDataJSON Data { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Save ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Save = (uint) (this.Flags & 1) > 0U;
      this.Data = (TLDataJSON) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Data, bw);
    }
  }
}
