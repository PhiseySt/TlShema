using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1107729093)]
  public class TLGame : TLObject
  {
    public override int Constructor => -1107729093;

    public int Flags { get; set; }

    public long Id { get; set; }

    public long AccessHash { get; set; }

    public string ShortName { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public TLAbsPhoto Photo { get; set; }

    public TLAbsDocument Document { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Document != null ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Id = br.ReadInt64();
      this.AccessHash = br.ReadInt64();
      this.ShortName = StringUtil.Deserialize(br);
      this.Title = StringUtil.Deserialize(br);
      this.Description = StringUtil.Deserialize(br);
      this.Photo = (TLAbsPhoto) ObjectUtils.DeserializeObject(br);
      if ((this.Flags & 1) != 0)
        this.Document = (TLAbsDocument) ObjectUtils.DeserializeObject(br);
      else
        this.Document = (TLAbsDocument) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Id);
      bw.Write(this.AccessHash);
      StringUtil.Serialize(this.ShortName, bw);
      StringUtil.Serialize(this.Title, bw);
      StringUtil.Serialize(this.Description, bw);
      ObjectUtils.SerializeObject((object) this.Photo, bw);
      if ((this.Flags & 1) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.Document, bw);
    }
  }
}
