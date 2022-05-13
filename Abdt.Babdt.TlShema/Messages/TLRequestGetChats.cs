using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(1013621127)]
  public class TLRequestGetChats : TLMethod
  {
    public override int Constructor => 1013621127;

    public TLVector<int> Id { get; set; }

    public TLAbsChats Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Id = ObjectUtils.DeserializeVector<int>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsChats) ObjectUtils.DeserializeObject(br);
  }
}
