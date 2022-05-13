using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1678949555)]
  public class TLInputWebDocument : TLObject
  {
    public override int Constructor => -1678949555;

    public string Url { get; set; }

    public int Size { get; set; }

    public string MimeType { get; set; }

    public TLVector<TLAbsDocumentAttribute> Attributes { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Url = StringUtil.Deserialize(br);
      this.Size = br.ReadInt32();
      this.MimeType = StringUtil.Deserialize(br);
      this.Attributes = ObjectUtils.DeserializeVector<TLAbsDocumentAttribute>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Url, bw);
      bw.Write(this.Size);
      StringUtil.Serialize(this.MimeType, bw);
      ObjectUtils.SerializeObject((object) this.Attributes, bw);
    }
  }
}
