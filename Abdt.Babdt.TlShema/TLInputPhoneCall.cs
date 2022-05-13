using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(506920429)]
  public class TLInputPhoneCall : TLObject
  {
    public override int Constructor => 506920429;

    public long Id { get; set; }

    public long AccessHash { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt64();
      this.AccessHash = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      bw.Write(this.AccessHash);
    }
  }
}
