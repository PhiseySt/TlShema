using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1670052855)]
  public class TLFoundGifCached : TLAbsFoundGif
  {
    public override int Constructor => -1670052855;

    public string Url { get; set; }

    public TLAbsPhoto Photo { get; set; }

    public TLAbsDocument Document { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Url = StringUtil.Deserialize(br);
      this.Photo = (TLAbsPhoto) ObjectUtils.DeserializeObject(br);
      this.Document = (TLAbsDocument) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Url, bw);
      ObjectUtils.SerializeObject((object) this.Photo, bw);
      ObjectUtils.SerializeObject((object) this.Document, bw);
    }
  }
}
