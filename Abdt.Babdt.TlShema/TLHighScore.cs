using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1493171408)]
  public class TLHighScore : TLObject
  {
    public override int Constructor => 1493171408;

    public int Pos { get; set; }

    public int UserId { get; set; }

    public int Score { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Pos = br.ReadInt32();
      this.UserId = br.ReadInt32();
      this.Score = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Pos);
      bw.Write(this.UserId);
      bw.Write(this.Score);
    }
  }
}
