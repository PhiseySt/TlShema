using System.IO;

namespace Abdt.Babdt.TlShema.Auth
{
  [TLObject(-440401971)]
  public class TLRequestExportAuthorization : TLMethod
  {
    public override int Constructor => -440401971;

    public int DcId { get; set; }

    public TLExportedAuthorization Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.DcId = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.DcId);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLExportedAuthorization) ObjectUtils.DeserializeObject(br);
  }
}
