using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(766298703)]
  public class TLRequestGetFeaturedStickers : TLMethod
  {
    public override int Constructor => 766298703;

    public int Hash { get; set; }

    public TLAbsFeaturedStickers Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Hash = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Hash);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsFeaturedStickers) ObjectUtils.DeserializeObject(br);
  }
}
