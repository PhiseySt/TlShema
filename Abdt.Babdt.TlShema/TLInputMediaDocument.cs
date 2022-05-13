
using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(444068508)]
  public class TLInputMediaDocument : TLAbsInputMedia
  {
    public override int Constructor => 444068508;

    public TLAbsInputDocument Id { get; set; }

    public string Caption { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = (TLAbsInputDocument) ObjectUtils.DeserializeObject(br);
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
