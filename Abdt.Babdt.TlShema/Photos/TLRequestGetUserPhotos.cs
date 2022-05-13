using System.IO;

namespace Abdt.Babdt.TlShema.Photos
{
  [TLObject(-1848823128)]
  public class TLRequestGetUserPhotos : TLMethod
  {
    public override int Constructor => -1848823128;

    public TLAbsInputUser UserId { get; set; }

    public int Offset { get; set; }

    public long MaxId { get; set; }

    public int Limit { get; set; }

    public TLAbsPhotos Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.Offset = br.ReadInt32();
      this.MaxId = br.ReadInt64();
      this.Limit = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
      bw.Write(this.Offset);
      bw.Write(this.MaxId);
      bw.Write(this.Limit);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsPhotos) ObjectUtils.DeserializeObject(br);
  }
}
