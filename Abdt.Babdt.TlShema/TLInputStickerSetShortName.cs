using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-2044933984)]
  public class TLInputStickerSetShortName : TLAbsInputStickerSet
  {
    public override int Constructor => -2044933984;

    public string ShortName { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.ShortName = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.ShortName, bw);
    }
  }
}
