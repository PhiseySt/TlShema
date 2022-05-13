using System.IO;

namespace Abdt.Babdt.TlShema.Account
{
  [TLObject(608323678)]
  public class TLRequestSetAccountTTL : TLMethod
  {
    public override int Constructor => 608323678;

    public TLAccountDaysTTL Ttl { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Ttl = (TLAccountDaysTTL) ObjectUtils.DeserializeObject(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Ttl, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
