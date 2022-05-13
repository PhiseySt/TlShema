using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(313694676)]
  public class TLStickerPack : TLObject
  {
    public override int Constructor => 313694676;

    public string Emoticon { get; set; }

    public TLVector<long> Documents { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Emoticon = StringUtil.Deserialize(br);
      this.Documents = ObjectUtils.DeserializeVector<long>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Emoticon, bw);
      ObjectUtils.SerializeObject((object) this.Documents, bw);
    }
  }
}
