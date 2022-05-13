using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-247351839)]
  public class TLInputEncryptedChat : TLObject
  {
    public override int Constructor => -247351839;

    public int ChatId { get; set; }

    public long AccessHash { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ChatId = br.ReadInt32();
      this.AccessHash = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChatId);
      bw.Write(this.AccessHash);
    }
  }
}
