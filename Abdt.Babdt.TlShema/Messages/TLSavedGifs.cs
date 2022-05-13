using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(772213157)]
  public class TLSavedGifs : TLAbsSavedGifs
  {
    public override int Constructor => 772213157;

    public int Hash { get; set; }

    public TLVector<TLAbsDocument> Gifs { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Hash = br.ReadInt32();
      this.Gifs = ObjectUtils.DeserializeVector<TLAbsDocument>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Hash);
      ObjectUtils.SerializeObject((object) this.Gifs, bw);
    }
  }
}
