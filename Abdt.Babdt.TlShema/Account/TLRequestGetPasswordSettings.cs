using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(-1131605573)]
  public class TLRequestGetPasswordSettings : TLMethod
  {
    public override int Constructor => -1131605573;

    public byte[] CurrentPasswordHash { get; set; }

    public TLPasswordSettings Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.CurrentPasswordHash = BytesUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BytesUtil.Serialize(this.CurrentPasswordHash, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLPasswordSettings) ObjectUtils.DeserializeObject(br);
  }
}
