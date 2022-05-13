using System.IO;

namespace Abdt.Babdt.TlShema.Users
{
  [TLObject(-902781519)]
  public class TLRequestGetFullUser : TLMethod
  {
    public override int Constructor => -902781519;

    public TLAbsInputUser Id { get; set; }

    public TLUserFull Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Id = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLUserFull) ObjectUtils.DeserializeObject(br);
  }
}
