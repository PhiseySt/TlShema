using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(1364105629)]
  public class TLRequestGetInlineBotResults : TLMethod
  {
    public override int Constructor => 1364105629;

    public int Flags { get; set; }

    public TLAbsInputUser Bot { get; set; }

    public TLAbsInputPeer Peer { get; set; }

    public TLAbsInputGeoPoint GeoPoint { get; set; }

    public string Query { get; set; }

    public string Offset { get; set; }

    public TLBotResults Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.GeoPoint != null ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Bot = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.GeoPoint = (this.Flags & 1) == 0 ? (TLAbsInputGeoPoint) null : (TLAbsInputGeoPoint) ObjectUtils.DeserializeObject(br);
      this.Query = StringUtil.Deserialize(br);
      this.Offset = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Bot, bw);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      if ((this.Flags & 1) != 0)
        ObjectUtils.SerializeObject((object) this.GeoPoint, bw);
      StringUtil.Serialize(this.Query, bw);
      StringUtil.Serialize(this.Offset, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLBotResults) ObjectUtils.DeserializeObject(br);
  }
}
