using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1655957568)]
  public class TLPhoneConnection : TLObject
  {
    public override int Constructor => -1655957568;

    public long Id { get; set; }

    public string Ip { get; set; }

    public string Ipv6 { get; set; }

    public int Port { get; set; }

    public byte[] PeerTag { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt64();
      this.Ip = StringUtil.Deserialize(br);
      this.Ipv6 = StringUtil.Deserialize(br);
      this.Port = br.ReadInt32();
      this.PeerTag = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      StringUtil.Serialize(this.Ip, bw);
      StringUtil.Serialize(this.Ipv6, bw);
      bw.Write(this.Port);
      BytesUtil.Serialize(this.PeerTag, bw);
    }
  }
}
