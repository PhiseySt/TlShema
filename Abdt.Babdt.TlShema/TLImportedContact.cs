using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-805141448)]
  public class TLImportedContact : TLObject
  {
    public override int Constructor => -805141448;

    public int UserId { get; set; }

    public long ClientId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = br.ReadInt32();
      this.ClientId = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.UserId);
      bw.Write(this.ClientId);
    }
  }
}
