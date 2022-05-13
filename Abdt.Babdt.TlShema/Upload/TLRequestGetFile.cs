using System.IO;

namespace Abdt.Babdt.TlShema.Upload
{
  [TLObject(-475607115)]
  public class TLRequestGetFile : TLMethod
  {
    public override int Constructor => -475607115;

    public TLAbsInputFileLocation Location { get; set; }

    public int Offset { get; set; }

    public int Limit { get; set; }

    public TLAbsFile Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Location = (TLAbsInputFileLocation) ObjectUtils.DeserializeObject(br);
      this.Offset = br.ReadInt32();
      this.Limit = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Location, bw);
      bw.Write(this.Offset);
      bw.Write(this.Limit);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsFile) ObjectUtils.DeserializeObject(br);
  }
}
