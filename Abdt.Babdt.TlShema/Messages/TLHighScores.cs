using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-1707344487)]
  public class TLHighScores : TLObject
  {
    public override int Constructor => -1707344487;

    public TLVector<TLHighScore> Scores { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Scores = ObjectUtils.DeserializeVector<TLHighScore>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Scores, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
