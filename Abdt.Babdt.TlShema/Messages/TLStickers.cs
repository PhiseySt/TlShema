using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-1970352846)]
  public class TLStickers : TLAbsStickers
  {
    public override int Constructor => -1970352846;

    public string Hash { get; set; }

    public TLVector<TLAbsDocument> Stickers { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Hash = StringUtil.Deserialize(br);
      this.Stickers = ObjectUtils.DeserializeVector<TLAbsDocument>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Hash, bw);
      ObjectUtils.SerializeObject((object) this.Stickers, bw);
    }
  }
}
