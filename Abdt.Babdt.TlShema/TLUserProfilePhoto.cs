using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-715532088)]
  public class TLUserProfilePhoto : TLAbsUserProfilePhoto
  {
    public override int Constructor => -715532088;

    public long PhotoId { get; set; }

    public TLAbsFileLocation PhotoSmall { get; set; }

    public TLAbsFileLocation PhotoBig { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PhotoId = br.ReadInt64();
      this.PhotoSmall = (TLAbsFileLocation) ObjectUtils.DeserializeObject(br);
      this.PhotoBig = (TLAbsFileLocation) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.PhotoId);
      ObjectUtils.SerializeObject((object) this.PhotoSmall, bw);
      ObjectUtils.SerializeObject((object) this.PhotoBig, bw);
    }
  }
}
