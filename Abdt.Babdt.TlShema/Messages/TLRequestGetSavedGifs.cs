using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-2084618926)]
  public class TLRequestGetSavedGifs : TLMethod
  {
    public override int Constructor => -2084618926;

    public int Hash { get; set; }

    public TLAbsSavedGifs Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Hash = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Hash);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsSavedGifs) ObjectUtils.DeserializeObject(br);
  }
}
