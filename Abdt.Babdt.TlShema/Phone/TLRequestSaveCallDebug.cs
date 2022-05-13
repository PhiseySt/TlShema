using System.IO;

namespace Abdt.Babdt.TlShema.Phone
{
  [TLObject(662363518)]
  public class TLRequestSaveCallDebug : TLMethod
  {
    public override int Constructor => 662363518;

    public TLInputPhoneCall Peer { get; set; }

    public TLDataJSON Debug { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLInputPhoneCall) ObjectUtils.DeserializeObject(br);
      this.Debug = (TLDataJSON) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      ObjectUtils.SerializeObject((object) this.Debug, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = BoolUtil.Deserialize(br);
  }
}
