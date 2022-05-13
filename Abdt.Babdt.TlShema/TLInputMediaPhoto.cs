using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-373312269)]
  public class TLInputMediaPhoto : TLAbsInputMedia
  {
    public override int Constructor => -373312269;

    public TLAbsInputPhoto Id { get; set; }

    public string Caption { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = (TLAbsInputPhoto) ObjectUtils.DeserializeObject(br);
      this.Caption = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
      StringUtil.Serialize(this.Caption, bw);
    }
  }
}
