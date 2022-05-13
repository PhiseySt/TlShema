using System.IO;

namespace Abdt.Babdt.TlShema.Payments
{
  [TLObject(-667062079)]
  public class TLRequestClearSavedInfo : TLMethod
  {
    public override int Constructor => -667062079;

    public int Flags { get; set; }

    public bool Credentials { get; set; }

    public bool Info { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Credentials ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Info ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Credentials = (uint) (this.Flags & 1) > 0U;
      this.Info = (uint) (this.Flags & 2) > 0U;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
