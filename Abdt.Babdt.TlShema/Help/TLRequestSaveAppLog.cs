using System.IO;

namespace Abdt.Babdt.TlShema.Help
{
  [TLObject(1862465352)]
  public class TLRequestSaveAppLog : TLMethod
  {
    public override int Constructor => 1862465352;

    public TLVector<TLInputAppEvent> Events { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Events = ObjectUtils.DeserializeVector<TLInputAppEvent>(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Events, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
