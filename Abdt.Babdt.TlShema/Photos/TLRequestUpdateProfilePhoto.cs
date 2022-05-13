using System.IO;

namespace Abdt.Babdt.TlShema.Photos
{
  [TLObject(-256159406)]
  public class TLRequestUpdateProfilePhoto : TLMethod
  {
    public override int Constructor => -256159406;

    public TLAbsInputPhoto Id { get; set; }

    public TLAbsUserProfilePhoto Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Id = (TLAbsInputPhoto) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUserProfilePhoto) ObjectUtils.DeserializeObject(br);
  }
}
