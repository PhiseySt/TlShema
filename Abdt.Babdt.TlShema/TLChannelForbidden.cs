using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-2059962289)]
  public class TLChannelForbidden : TLAbsChat
  {
    public override int Constructor => -2059962289;

    public int Flags { get; set; }

    public bool Broadcast { get; set; }

    public bool Megagroup { get; set; }

    public int Id { get; set; }

    public long AccessHash { get; set; }

    public string Title { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Broadcast ? this.Flags | 32 : this.Flags & -33;
      this.Flags = this.Megagroup ? this.Flags | 256 : this.Flags & -257;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Broadcast = (uint) (this.Flags & 32) > 0U;
      this.Megagroup = (uint) (this.Flags & 256) > 0U;
      this.Id = br.ReadInt32();
      this.AccessHash = br.ReadInt64();
      this.Title = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Id);
      bw.Write(this.AccessHash);
      StringUtil.Serialize(this.Title, bw);
    }
  }
}
