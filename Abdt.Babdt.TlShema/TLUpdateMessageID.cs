using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1318109142)]
  public class TLUpdateMessageID : TLAbsUpdate
  {
    public override int Constructor => 1318109142;

    public int Id { get; set; }

    public long RandomId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt32();
      this.RandomId = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      bw.Write(this.RandomId);
    }
  }
}
