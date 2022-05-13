using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1009430225)]
  public class TLChannelFull : TLAbsChatFull
  {
    public override int Constructor => -1009430225;

    public int Flags { get; set; }

    public bool CanViewParticipants { get; set; }

    public bool CanSetUsername { get; set; }

    public int Id { get; set; }

    public string About { get; set; }

    public int? ParticipantsCount { get; set; }

    public int? AdminsCount { get; set; }

    public int? KickedCount { get; set; }

    public int ReadInboxMaxId { get; set; }

    public int ReadOutboxMaxId { get; set; }

    public int UnreadCount { get; set; }

    public TLAbsPhoto ChatPhoto { get; set; }

    public TLAbsPeerNotifySettings NotifySettings { get; set; }

    public TLAbsExportedChatInvite ExportedInvite { get; set; }

    public TLVector<TLBotInfo> BotInfo { get; set; }

    public int? MigratedFromChatId { get; set; }

    public int? MigratedFromMaxId { get; set; }

    public int? PinnedMsgId { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.CanViewParticipants ? this.Flags | 8 : this.Flags & -9;
      this.Flags = this.CanSetUsername ? this.Flags | 64 : this.Flags & -65;
      this.Flags = this.ParticipantsCount.HasValue ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.AdminsCount.HasValue ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.KickedCount.HasValue ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.MigratedFromChatId.HasValue ? this.Flags | 16 : this.Flags & -17;
      this.Flags = this.MigratedFromMaxId.HasValue ? this.Flags | 16 : this.Flags & -17;
      this.Flags = this.PinnedMsgId.HasValue ? this.Flags | 32 : this.Flags & -33;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.CanViewParticipants = (uint) (this.Flags & 8) > 0U;
      this.CanSetUsername = (uint) (this.Flags & 64) > 0U;
      this.Id = br.ReadInt32();
      this.About = StringUtil.Deserialize(br);
      this.ParticipantsCount = (this.Flags & 1) == 0 ? new int?() : new int?(br.ReadInt32());
      this.AdminsCount = (this.Flags & 2) == 0 ? new int?() : new int?(br.ReadInt32());
      this.KickedCount = (this.Flags & 4) == 0 ? new int?() : new int?(br.ReadInt32());
      this.ReadInboxMaxId = br.ReadInt32();
      this.ReadOutboxMaxId = br.ReadInt32();
      this.UnreadCount = br.ReadInt32();
      this.ChatPhoto = (TLAbsPhoto) ObjectUtils.DeserializeObject(br);
      this.NotifySettings = (TLAbsPeerNotifySettings) ObjectUtils.DeserializeObject(br);
      this.ExportedInvite = (TLAbsExportedChatInvite) ObjectUtils.DeserializeObject(br);
      this.BotInfo = ObjectUtils.DeserializeVector<TLBotInfo>(br);
      this.MigratedFromChatId = (this.Flags & 16) == 0 ? new int?() : new int?(br.ReadInt32());
      this.MigratedFromMaxId = (this.Flags & 16) == 0 ? new int?() : new int?(br.ReadInt32());
      if ((this.Flags & 32) != 0)
        this.PinnedMsgId = new int?(br.ReadInt32());
      else
        this.PinnedMsgId = new int?();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Id);
      StringUtil.Serialize(this.About, bw);
      if ((this.Flags & 1) != 0)
        bw.Write(this.ParticipantsCount.Value);
      if ((this.Flags & 2) != 0)
        bw.Write(this.AdminsCount.Value);
      if ((this.Flags & 4) != 0)
        bw.Write(this.KickedCount.Value);
      bw.Write(this.ReadInboxMaxId);
      bw.Write(this.ReadOutboxMaxId);
      bw.Write(this.UnreadCount);
      ObjectUtils.SerializeObject((object) this.ChatPhoto, bw);
      ObjectUtils.SerializeObject((object) this.NotifySettings, bw);
      ObjectUtils.SerializeObject((object) this.ExportedInvite, bw);
      ObjectUtils.SerializeObject((object) this.BotInfo, bw);
      if ((this.Flags & 16) != 0)
        bw.Write(this.MigratedFromChatId.Value);
      if ((this.Flags & 16) != 0)
        bw.Write(this.MigratedFromMaxId.Value);
      if ((this.Flags & 32) == 0)
        return;
      bw.Write(this.PinnedMsgId.Value);
    }
  }
}
