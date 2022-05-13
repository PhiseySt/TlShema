using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(911761060)]
  public class TLBotCallbackAnswer : TLObject
  {
    public override int Constructor => 911761060;

    public int Flags { get; set; }

    public bool Alert { get; set; }

    public bool HasUrl { get; set; }

    public string Message { get; set; }

    public string Url { get; set; }

    public int CacheTime { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Alert ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.HasUrl ? this.Flags | 8 : this.Flags & -9;
      this.Flags = this.Message != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Url != null ? this.Flags | 4 : this.Flags & -5;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Alert = (uint) (this.Flags & 2) > 0U;
      this.HasUrl = (uint) (this.Flags & 8) > 0U;
      this.Message = (this.Flags & 1) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Url = (this.Flags & 4) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.CacheTime = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      if ((this.Flags & 1) != 0)
        StringUtil.Serialize(this.Message, bw);
      if ((this.Flags & 4) != 0)
        StringUtil.Serialize(this.Url, bw);
      bw.Write(this.CacheTime);
    }
  }
}
