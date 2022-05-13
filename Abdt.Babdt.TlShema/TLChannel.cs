using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1588737454)]
  public class TLChannel : TLAbsChat
  {
    public override int Constructor => -1588737454;

    public int Flags { get; set; }

    public bool Creator { get; set; }

    public bool Kicked { get; set; }

    public bool Left { get; set; }

    public bool Editor { get; set; }

    public bool Moderator { get; set; }

    public bool Broadcast { get; set; }

    public bool Verified { get; set; }

    public bool Megagroup { get; set; }

    public bool Restricted { get; set; }

    public bool Democracy { get; set; }

    public bool Signatures { get; set; }

    public bool Min { get; set; }

    public int Id { get; set; }

    public long? AccessHash { get; set; }

    public string Title { get; set; }

    public string Username { get; set; }

    public TLAbsChatPhoto Photo { get; set; }

    public int Date { get; set; }

    public int Version { get; set; }

    public string RestrictionReason { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Creator ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Kicked ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Left ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.Editor ? this.Flags | 8 : this.Flags & -9;
      this.Flags = this.Moderator ? this.Flags | 16 : this.Flags & -17;
      this.Flags = this.Broadcast ? this.Flags | 32 : this.Flags & -33;
      this.Flags = this.Verified ? this.Flags | 128 : this.Flags & -129;
      this.Flags = this.Megagroup ? this.Flags | 256 : this.Flags & -257;
      this.Flags = this.Restricted ? this.Flags | 512 : this.Flags & -513;
      this.Flags = this.Democracy ? this.Flags | 1024 : this.Flags & -1025;
      this.Flags = this.Signatures ? this.Flags | 2048 : this.Flags & -2049;
      this.Flags = this.Min ? this.Flags | 4096 : this.Flags & -4097;
      this.Flags = this.AccessHash.HasValue ? this.Flags | 8192 : this.Flags & -8193;
      this.Flags = this.Username != null ? this.Flags | 64 : this.Flags & -65;
      this.Flags = this.RestrictionReason != null ? this.Flags | 512 : this.Flags & -513;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Creator = (uint) (this.Flags & 1) > 0U;
      this.Kicked = (uint) (this.Flags & 2) > 0U;
      this.Left = (uint) (this.Flags & 4) > 0U;
      this.Editor = (uint) (this.Flags & 8) > 0U;
      this.Moderator = (uint) (this.Flags & 16) > 0U;
      this.Broadcast = (uint) (this.Flags & 32) > 0U;
      this.Verified = (uint) (this.Flags & 128) > 0U;
      this.Megagroup = (uint) (this.Flags & 256) > 0U;
      this.Restricted = (uint) (this.Flags & 512) > 0U;
      this.Democracy = (uint) (this.Flags & 1024) > 0U;
      this.Signatures = (uint) (this.Flags & 2048) > 0U;
      this.Min = (uint) (this.Flags & 4096) > 0U;
      this.Id = br.ReadInt32();
      this.AccessHash = (this.Flags & 8192) == 0 ? new long?() : new long?(br.ReadInt64());
      this.Title = StringUtil.Deserialize(br);
      this.Username = (this.Flags & 64) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Photo = (TLAbsChatPhoto) ObjectUtils.DeserializeObject(br);
      this.Date = br.ReadInt32();
      this.Version = br.ReadInt32();
      if ((this.Flags & 512) != 0)
        this.RestrictionReason = StringUtil.Deserialize(br);
      else
        this.RestrictionReason = (string) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Id);
      if ((this.Flags & 8192) != 0)
        bw.Write(this.AccessHash.Value);
      StringUtil.Serialize(this.Title, bw);
      if ((this.Flags & 64) != 0)
        StringUtil.Serialize(this.Username, bw);
      ObjectUtils.SerializeObject((object) this.Photo, bw);
      bw.Write(this.Date);
      bw.Write(this.Version);
      if ((this.Flags & 512) == 0)
        return;
      StringUtil.Serialize(this.RestrictionReason, bw);
    }
  }
}
