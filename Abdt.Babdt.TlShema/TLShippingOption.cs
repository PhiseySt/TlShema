using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1239335713)]
  public class TLShippingOption : TLObject
  {
    public override int Constructor => -1239335713;

    public string Id { get; set; }

    public string Title { get; set; }

    public TLVector<TLLabeledPrice> Prices { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = StringUtil.Deserialize(br);
      this.Title = StringUtil.Deserialize(br);
      this.Prices = ObjectUtils.DeserializeVector<TLLabeledPrice>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Id, bw);
      StringUtil.Serialize(this.Title, bw);
      ObjectUtils.SerializeObject((object) this.Prices, bw);
    }
  }
}
