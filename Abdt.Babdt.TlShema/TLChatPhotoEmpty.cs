using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(935395612)]
  public class TLChatPhotoEmpty : TLAbsChatPhoto
  {
    public override int Constructor => 935395612;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
