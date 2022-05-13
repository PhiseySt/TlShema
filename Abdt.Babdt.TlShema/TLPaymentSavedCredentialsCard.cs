using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-842892769)]
  public class TLPaymentSavedCredentialsCard : TLObject
  {
    public override int Constructor => -842892769;

    public string Id { get; set; }

    public string Title { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = StringUtil.Deserialize(br);
      this.Title = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Id, bw);
      StringUtil.Serialize(this.Title, bw);
    }
  }
}
