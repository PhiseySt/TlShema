using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1697798976)]
  public class TLPeerNotifySettings : TLAbsPeerNotifySettings
  {
    public override int Constructor => -1697798976;

    public int Flags { get; set; }

    public bool ShowPreviews { get; set; }

    public bool Silent { get; set; }

    public int MuteUntil { get; set; }

    public string Sound { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.ShowPreviews ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Silent ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.ShowPreviews = (uint) (this.Flags & 1) > 0U;
      this.Silent = (uint) (this.Flags & 2) > 0U;
      this.MuteUntil = br.ReadInt32();
      this.Sound = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.MuteUntil);
      StringUtil.Serialize(this.Sound, bw);
    }
  }
}
