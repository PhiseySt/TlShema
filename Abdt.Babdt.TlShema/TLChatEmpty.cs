using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1683826688)]
  public class TLChatEmpty : TLAbsChat
  {
    public override int Constructor => -1683826688;

    public int Id { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Id = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
    }
  }
}
