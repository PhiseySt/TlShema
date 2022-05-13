using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-421563528)]
  public class TLRequestStartBot : TLMethod
  {
    public override int Constructor => -421563528;

    public TLAbsInputUser Bot { get; set; }

    public TLAbsInputPeer Peer { get; set; }

    public long RandomId { get; set; }

    public string StartParam { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Bot = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.RandomId = br.ReadInt64();
      this.StartParam = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Bot, bw);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.RandomId);
      StringUtil.Serialize(this.StartParam, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
