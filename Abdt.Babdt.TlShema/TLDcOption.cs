using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(98092748)]
  public class TLDcOption : TLObject
  {
    public override int Constructor => 98092748;

    public int Flags { get; set; }

    public bool Ipv6 { get; set; }

    public bool MediaOnly { get; set; }

    public bool TcpoOnly { get; set; }

    public bool Cdn { get; set; }

    public int Id { get; set; }

    public string IpAddress { get; set; }

    public int Port { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Ipv6 ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.MediaOnly ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.TcpoOnly ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.Cdn ? this.Flags | 8 : this.Flags & -9;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Ipv6 = (uint) (this.Flags & 1) > 0U;
      this.MediaOnly = (uint) (this.Flags & 2) > 0U;
      this.TcpoOnly = (uint) (this.Flags & 4) > 0U;
      this.Cdn = (uint) (this.Flags & 8) > 0U;
      this.Id = br.ReadInt32();
      this.IpAddress = StringUtil.Deserialize(br);
      this.Port = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Id);
      StringUtil.Serialize(this.IpAddress, bw);
      bw.Write(this.Port);
    }
  }
}
