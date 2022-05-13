using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1406570614)]
  public class TLFileLocation : TLAbsFileLocation
  {
    public override int Constructor => 1406570614;

    public int DcId { get; set; }

    public long VolumeId { get; set; }

    public int LocalId { get; set; }

    public long Secret { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.DcId = br.ReadInt32();
      this.VolumeId = br.ReadInt64();
      this.LocalId = br.ReadInt32();
      this.Secret = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.DcId);
      bw.Write(this.VolumeId);
      bw.Write(this.LocalId);
      bw.Write(this.Secret);
    }
  }
}
