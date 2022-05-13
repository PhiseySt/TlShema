using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-886477832)]
  public class TLLabeledPrice : TLObject
  {
    public override int Constructor => -886477832;

    public string Label { get; set; }

    public long Amount { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Label = StringUtil.Deserialize(br);
      this.Amount = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Label, bw);
      bw.Write(this.Amount);
    }
  }
}
