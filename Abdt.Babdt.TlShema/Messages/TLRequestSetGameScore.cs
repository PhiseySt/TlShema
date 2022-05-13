using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(-1896289088)]
  public class TLRequestSetGameScore : TLMethod
  {
    public override int Constructor => -1896289088;

    public int Flags { get; set; }

    public bool EditMessage { get; set; }

    public bool Force { get; set; }

    public TLAbsInputPeer Peer { get; set; }

    public int Id { get; set; }

    public TLAbsInputUser UserId { get; set; }

    public int Score { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.EditMessage ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Force ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.EditMessage = (uint) (this.Flags & 1) > 0U;
      this.Force = (uint) (this.Flags & 2) > 0U;
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.Id = br.ReadInt32();
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.Score = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.Id);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
      bw.Write(this.Score);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
