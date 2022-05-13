using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-2134272152)]
  public class TLInputMessagesFilterPhoneCalls : TLAbsMessagesFilter
  {
    public override int Constructor => -2134272152;

    public int Flags { get; set; }

    public bool Missed { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Missed ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Missed = (uint) (this.Flags & 1) > 0U;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
    }
  }
}
