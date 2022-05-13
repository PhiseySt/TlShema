using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1036396922)]
  public class TLInputWebFileLocation : TLObject
  {
    public override int Constructor => -1036396922;

    public string Url { get; set; }

    public long AccessHash { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Url = StringUtil.Deserialize(br);
      this.AccessHash = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Url, bw);
      bw.Write(this.AccessHash);
    }
  }
}
