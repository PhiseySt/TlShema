using System.IO;

namespace Abdt.Babdt.TlShema.Bots
{
  [TLObject(-434028723)]
  public class TLRequestAnswerWebhookJSONQuery : TLMethod
  {
    public override int Constructor => -434028723;

    public long QueryId { get; set; }

    public TLDataJSON Data { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.QueryId = br.ReadInt64();
      this.Data = (TLDataJSON) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.QueryId);
      ObjectUtils.SerializeObject((object) this.Data, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
