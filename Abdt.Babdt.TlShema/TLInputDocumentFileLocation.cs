using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1125058340)]
  public class TLInputDocumentFileLocation : TLAbsInputFileLocation
  {
    public override int Constructor => 1125058340;

    public long Id { get; set; }

    public long AccessHash { get; set; }

    public int Version { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt64();
      this.AccessHash = br.ReadInt64();
      this.Version = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      bw.Write(this.AccessHash);
      bw.Write(this.Version);
    }
  }
}
