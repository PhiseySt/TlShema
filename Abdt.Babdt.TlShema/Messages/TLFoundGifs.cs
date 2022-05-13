using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(1158290442)]
  public class TLFoundGifs : TLObject
  {
    public override int Constructor => 1158290442;

    public int NextOffset { get; set; }

    public TLVector<TLAbsFoundGif> Results { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.NextOffset = br.ReadInt32();
      this.Results = ObjectUtils.DeserializeVector<TLAbsFoundGif>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.NextOffset);
      ObjectUtils.SerializeObject((object) this.Results, bw);
    }
  }
}
