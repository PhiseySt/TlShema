using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1834538890)]
  public class TLMessageActionGameScore : TLAbsMessageAction
  {
    public override int Constructor => -1834538890;

    public long GameId { get; set; }

    public int Score { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.GameId = br.ReadInt64();
      this.Score = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.GameId);
      bw.Write(this.Score);
    }
  }
}
