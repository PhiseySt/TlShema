using System.IO;

namespace Abdt.Babdt.TlShema.Help
{
  [TLObject(-1877938321)]
  public class TLRequestGetAppChangelog : TLMethod
  {
    public override int Constructor => -1877938321;

    public string PrevAppVersion { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.PrevAppVersion = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.PrevAppVersion, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
