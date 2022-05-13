using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(1527873830)]
  public class TLRequestReadFeaturedStickers : TLMethod
  {
    public override int Constructor => 1527873830;

    public TLVector<long> Id { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Id = ObjectUtils.DeserializeVector<long>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
