using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-523384512)]
  public class TLUpdateBotShippingQuery : TLAbsUpdate
  {
    public override int Constructor => -523384512;

    public long QueryId { get; set; }

    public int UserId { get; set; }

    public byte[] Payload { get; set; }

    public TLPostAddress ShippingAddress { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.QueryId = br.ReadInt64();
      this.UserId = br.ReadInt32();
      this.Payload = BytesUtil.Deserialize(br);
      this.ShippingAddress = (TLPostAddress) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.QueryId);
      bw.Write(this.UserId);
      BytesUtil.Serialize(this.Payload, bw);
      ObjectUtils.SerializeObject((object) this.ShippingAddress, bw);
    }
  }
}
