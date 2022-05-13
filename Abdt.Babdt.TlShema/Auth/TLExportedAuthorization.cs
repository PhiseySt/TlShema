using System.IO;

namespace Abdt.Babdt.TlShema.Auth
{
  [TLObject(-543777747)]
  public class TLExportedAuthorization : TLObject
  {
    public override int Constructor => -543777747;

    public int Id { get; set; }

    public byte[] Bytes { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt32();
      this.Bytes = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      BytesUtil.Serialize(this.Bytes, bw);
    }
  }
}
