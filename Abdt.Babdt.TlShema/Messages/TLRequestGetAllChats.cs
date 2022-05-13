using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-341307408)]
  public class TLRequestGetAllChats : TLMethod
  {
    public override int Constructor => -341307408;

    public TLVector<int> ExceptIds { get; set; }

    public TLAbsChats Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.ExceptIds = ObjectUtils.DeserializeVector<int>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.ExceptIds, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsChats) ObjectUtils.DeserializeObject(br);
  }
}
