using System.IO;

namespace Abdt.Babdt.TlShema.Photos
{
  [TLObject(-2016444625)]
  public class TLRequestDeletePhotos : TLMethod
  {
    public override int Constructor => -2016444625;

    public TLVector<TLAbsInputPhoto> Id { get; set; }

    public TLVector<long> Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Id = ObjectUtils.DeserializeVector<TLAbsInputPhoto>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = ObjectUtils.DeserializeVector<long>(br);
  }
}
