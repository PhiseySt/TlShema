using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-750828557)]
  public class TLInputMediaGame : TLAbsInputMedia
  {
    public override int Constructor => -750828557;

    public TLAbsInputGame Id { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Id = (TLAbsInputGame) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }
  }
}
