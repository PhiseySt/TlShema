using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-38694904)]
  public class TLMessageMediaGame : TLAbsMessageMedia
  {
    public override int Constructor => -38694904;

    public TLGame Game { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Game = (TLGame) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Game, bw);
    }
  }
}
