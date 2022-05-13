using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(1706608543)]
  public class TLRequestGetMaskStickers : TLMethod
  {
    public override int Constructor => 1706608543;

    public int Hash { get; set; }

    public TLAbsAllStickers Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Hash = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Hash);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsAllStickers) ObjectUtils.DeserializeObject(br);
  }
}
