using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(649453030)]
  public class TLMessageEditData : TLObject
  {
    public override int Constructor => 649453030;

    public int Flags { get; set; }

    public bool Caption { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Caption ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Caption = (uint) (this.Flags & 1) > 0U;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
    }
  }
}
