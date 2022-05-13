using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(651135312)]
  public class TLRequestGetDhConfig : TLMethod
  {
    public override int Constructor => 651135312;

    public int Version { get; set; }

    public int RandomLength { get; set; }

    public TLAbsDhConfig Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Version = br.ReadInt32();
      this.RandomLength = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Version);
      bw.Write(this.RandomLength);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsDhConfig) ObjectUtils.DeserializeObject(br);
  }
}
