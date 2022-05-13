using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(150761757)]
  public class TLRequestGetAccountTTL : TLMethod
  {
    public override int Constructor => 150761757;

    public TLAccountDaysTTL Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAccountDaysTTL) ObjectUtils.DeserializeObject(br);
  }
}
