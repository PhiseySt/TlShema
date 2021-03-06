using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-116274796)]
  public class TLContact : TLObject
  {
    public override int Constructor => -116274796;

    public int UserId { get; set; }

    public bool Mutual { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = br.ReadInt32();
      this.Mutual = BoolUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.UserId);
      BoolUtil.Serialize(this.Mutual, bw);
    }
  }
}
