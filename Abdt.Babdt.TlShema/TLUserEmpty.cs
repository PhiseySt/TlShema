using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(537022650)]
  public class TLUserEmpty : TLAbsUser
  {
    public override int Constructor => 537022650;

    public int Id { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Id = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
    }
  }
}
