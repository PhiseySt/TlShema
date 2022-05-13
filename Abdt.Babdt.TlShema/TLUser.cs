using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(773059779)]
  public class TLUser : TLAbsUser
  {
    public override int Constructor => 773059779;

    public int Flags { get; set; }

    public bool Self { get; set; }

    public bool Contact { get; set; }

    public bool MutualContact { get; set; }

    public bool Deleted { get; set; }

    public bool Bot { get; set; }

    public bool BotChatHistory { get; set; }

    public bool BotNochats { get; set; }

    public bool Verified { get; set; }

    public bool Restricted { get; set; }

    public bool Min { get; set; }

    public bool BotInlineGeo { get; set; }

    public int Id { get; set; }

    public long? AccessHash { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Username { get; set; }

    public string Phone { get; set; }

    public TLAbsUserProfilePhoto Photo { get; set; }

    public TLAbsUserStatus Status { get; set; }

    public int? BotInfoVersion { get; set; }

    public string RestrictionReason { get; set; }

    public string BotInlinePlaceholder { get; set; }

    public string LangCode { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Self ? this.Flags | 1024 : this.Flags & -1025;
      this.Flags = this.Contact ? this.Flags | 2048 : this.Flags & -2049;
      this.Flags = this.MutualContact ? this.Flags | 4096 : this.Flags & -4097;
      this.Flags = this.Deleted ? this.Flags | 8192 : this.Flags & -8193;
      this.Flags = this.Bot ? this.Flags | 16384 : this.Flags & -16385;
      this.Flags = this.BotChatHistory ? this.Flags | 32768 : this.Flags & -32769;
      this.Flags = this.BotNochats ? this.Flags | 65536 : this.Flags & -65537;
      this.Flags = this.Verified ? this.Flags | 131072 : this.Flags & -131073;
      this.Flags = this.Restricted ? this.Flags | 262144 : this.Flags & -262145;
      this.Flags = this.Min ? this.Flags | 1048576 : this.Flags & -1048577;
      this.Flags = this.BotInlineGeo ? this.Flags | 2097152 : this.Flags & -2097153;
      this.Flags = this.AccessHash.HasValue ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.FirstName != null ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.LastName != null ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.Username != null ? this.Flags | 8 : this.Flags & -9;
      this.Flags = this.Phone != null ? this.Flags | 16 : this.Flags & -17;
      this.Flags = this.Photo != null ? this.Flags | 32 : this.Flags & -33;
      this.Flags = this.Status != null ? this.Flags | 64 : this.Flags & -65;
      this.Flags = this.BotInfoVersion.HasValue ? this.Flags | 16384 : this.Flags & -16385;
      this.Flags = this.RestrictionReason != null ? this.Flags | 262144 : this.Flags & -262145;
      this.Flags = this.BotInlinePlaceholder != null ? this.Flags | 524288 : this.Flags & -524289;
      this.Flags = this.LangCode != null ? this.Flags | 4194304 : this.Flags & -4194305;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Self = (uint) (this.Flags & 1024) > 0U;
      this.Contact = (uint) (this.Flags & 2048) > 0U;
      this.MutualContact = (uint) (this.Flags & 4096) > 0U;
      this.Deleted = (uint) (this.Flags & 8192) > 0U;
      this.Bot = (uint) (this.Flags & 16384) > 0U;
      this.BotChatHistory = (uint) (this.Flags & 32768) > 0U;
      this.BotNochats = (uint) (this.Flags & 65536) > 0U;
      this.Verified = (uint) (this.Flags & 131072) > 0U;
      this.Restricted = (uint) (this.Flags & 262144) > 0U;
      this.Min = (uint) (this.Flags & 1048576) > 0U;
      this.BotInlineGeo = (uint) (this.Flags & 2097152) > 0U;
      this.Id = br.ReadInt32();
      this.AccessHash = (this.Flags & 1) == 0 ? new long?() : new long?(br.ReadInt64());
      this.FirstName = (this.Flags & 2) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.LastName = (this.Flags & 4) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Username = (this.Flags & 8) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Phone = (this.Flags & 16) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Photo = (this.Flags & 32) == 0 ? (TLAbsUserProfilePhoto) null : (TLAbsUserProfilePhoto) ObjectUtils.DeserializeObject(br);
      this.Status = (this.Flags & 64) == 0 ? (TLAbsUserStatus) null : (TLAbsUserStatus) ObjectUtils.DeserializeObject(br);
      this.BotInfoVersion = (this.Flags & 16384) == 0 ? new int?() : new int?(br.ReadInt32());
      this.RestrictionReason = (this.Flags & 262144) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.BotInlinePlaceholder = (this.Flags & 524288) == 0 ? (string) null : StringUtil.Deserialize(br);
      if ((this.Flags & 4194304) != 0)
        this.LangCode = StringUtil.Deserialize(br);
      else
        this.LangCode = (string) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Id);
      if ((this.Flags & 1) != 0)
        bw.Write(this.AccessHash.Value);
      if ((this.Flags & 2) != 0)
        StringUtil.Serialize(this.FirstName, bw);
      if ((this.Flags & 4) != 0)
        StringUtil.Serialize(this.LastName, bw);
      if ((this.Flags & 8) != 0)
        StringUtil.Serialize(this.Username, bw);
      if ((this.Flags & 16) != 0)
        StringUtil.Serialize(this.Phone, bw);
      if ((this.Flags & 32) != 0)
        ObjectUtils.SerializeObject((object) this.Photo, bw);
      if ((this.Flags & 64) != 0)
        ObjectUtils.SerializeObject((object) this.Status, bw);
      if ((this.Flags & 16384) != 0)
        bw.Write(this.BotInfoVersion.Value);
      if ((this.Flags & 262144) != 0)
        StringUtil.Serialize(this.RestrictionReason, bw);
      if ((this.Flags & 524288) != 0)
        StringUtil.Serialize(this.BotInlinePlaceholder, bw);
      if ((this.Flags & 4194304) == 0)
        return;
      StringUtil.Serialize(this.LangCode, bw);
    }
  }
}
