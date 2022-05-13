using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(916930423)]
  public class TLRequestReadMessageContents : TLMethod
  {
    public override int Constructor => 916930423;

    public TLVector<int> Id { get; set; }

    public TLAffectedMessages Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Id = ObjectUtils.DeserializeVector<int>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAffectedMessages) ObjectUtils.DeserializeObject(br);
  }
}
