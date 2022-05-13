using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-994444869)]
  public class TLError : TLObject
  {
    public override int Constructor => -994444869;

    public int Code { get; set; }

    public string Text { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Code = br.ReadInt32();
      this.Text = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Code);
      StringUtil.Serialize(this.Text, bw);
    }
  }
}
