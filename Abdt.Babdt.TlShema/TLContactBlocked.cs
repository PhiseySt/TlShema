using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1444661369)]
  public class TLContactBlocked : TLObject
  {
    public override int Constructor => 1444661369;

    public int UserId { get; set; }

    public int Date { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = br.ReadInt32();
      this.Date = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.UserId);
      bw.Write(this.Date);
    }
  }
}
