using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-1080395925)]
  public class TLRequestSearchGifs : TLMethod
  {
    public override int Constructor => -1080395925;

    public string Q { get; set; }

    public int Offset { get; set; }

    public TLFoundGifs Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Q = StringUtil.Deserialize(br);
      this.Offset = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Q, bw);
      bw.Write(this.Offset);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLFoundGifs) ObjectUtils.DeserializeObject(br);
  }
}
