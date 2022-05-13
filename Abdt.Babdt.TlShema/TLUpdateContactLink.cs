using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1657903163)]
  public class TLUpdateContactLink : TLAbsUpdate
  {
    public override int Constructor => -1657903163;

    public int UserId { get; set; }

    public TLAbsContactLink MyLink { get; set; }

    public TLAbsContactLink ForeignLink { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = br.ReadInt32();
      this.MyLink = (TLAbsContactLink) ObjectUtils.DeserializeObject(br);
      this.ForeignLink = (TLAbsContactLink) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.UserId);
      ObjectUtils.SerializeObject((object) this.MyLink, bw);
      ObjectUtils.SerializeObject((object) this.ForeignLink, bw);
    }
  }
}
