using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1632839530)]
  public class TLChatPhoto : TLAbsChatPhoto
  {
    public override int Constructor => 1632839530;

    public TLAbsFileLocation PhotoSmall { get; set; }

    public TLAbsFileLocation PhotoBig { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PhotoSmall = (TLAbsFileLocation) ObjectUtils.DeserializeObject(br);
      this.PhotoBig = (TLAbsFileLocation) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.PhotoSmall, bw);
      ObjectUtils.SerializeObject((object) this.PhotoBig, bw);
    }
  }
}
