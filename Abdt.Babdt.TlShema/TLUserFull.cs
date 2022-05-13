using System.IO;
using Abdt.Babdt.TlShema.Contacts;

namespace Abdt.Babdt.TlShema
{
  [TLObject(253890367)]
  public class TLUserFull : TLObject
  {
    public override int Constructor => 253890367;

    public int Flags { get; set; }

    public bool Blocked { get; set; }

    public bool PhoneCallsAvailable { get; set; }

    public bool PhoneCallsPrivate { get; set; }

    public TLAbsUser User { get; set; }

    public string About { get; set; }

    public TLLink Link { get; set; }

    public TLAbsPhoto ProfilePhoto { get; set; }

    public TLAbsPeerNotifySettings NotifySettings { get; set; }

    public TLBotInfo BotInfo { get; set; }

    public int CommonChatsCount { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Blocked ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.PhoneCallsAvailable ? this.Flags | 16 : this.Flags & -17;
      this.Flags = this.PhoneCallsPrivate ? this.Flags | 32 : this.Flags & -33;
      this.Flags = this.About != null ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.ProfilePhoto != null ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.BotInfo != null ? this.Flags | 8 : this.Flags & -9;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Blocked = (uint) (this.Flags & 1) > 0U;
      this.PhoneCallsAvailable = (uint) (this.Flags & 16) > 0U;
      this.PhoneCallsPrivate = (uint) (this.Flags & 32) > 0U;
      this.User = (TLAbsUser) ObjectUtils.DeserializeObject(br);
      this.About = (this.Flags & 2) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Link = (TLLink) ObjectUtils.DeserializeObject(br);
      this.ProfilePhoto = (this.Flags & 4) == 0 ? (TLAbsPhoto) null : (TLAbsPhoto) ObjectUtils.DeserializeObject(br);
      this.NotifySettings = (TLAbsPeerNotifySettings) ObjectUtils.DeserializeObject(br);
      this.BotInfo = (this.Flags & 8) == 0 ? (TLBotInfo) null : (TLBotInfo) ObjectUtils.DeserializeObject(br);
      this.CommonChatsCount = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.User, bw);
      if ((this.Flags & 2) != 0)
        StringUtil.Serialize(this.About, bw);
      ObjectUtils.SerializeObject((object) this.Link, bw);
      if ((this.Flags & 4) != 0)
        ObjectUtils.SerializeObject((object) this.ProfilePhoto, bw);
      ObjectUtils.SerializeObject((object) this.NotifySettings, bw);
      if ((this.Flags & 8) != 0)
        ObjectUtils.SerializeObject((object) this.BotInfo, bw);
      bw.Write(this.CommonChatsCount);
    }
  }
}
