using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1194283041)]
  public class TLAccountDaysTTL : TLObject
  {
    public override int Constructor => -1194283041;

    public int Days { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Days = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Days);
    }
  }
}
