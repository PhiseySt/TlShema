using System.IO;

namespace Abdt.Babdt.TlShema.Messages
{
  [TLObject(1888354709)]
  public class TLRequestForwardMessages : TLMethod
  {
    public override int Constructor => 1888354709;

    public int Flags { get; set; }

    public bool Silent { get; set; }

    public bool Background { get; set; }

    public bool WithMyScore { get; set; }

    public TLAbsInputPeer FromPeer { get; set; }

    public TLVector<int> Id { get; set; }

    public TLVector<long> RandomId { get; set; }

    public TLAbsInputPeer ToPeer { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Silent ? this.Flags | 32 : this.Flags & -33;
      this.Flags = this.Background ? this.Flags | 64 : this.Flags & -65;
      this.Flags = this.WithMyScore ? this.Flags | 256 : this.Flags & -257;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Silent = (uint) (this.Flags & 32) > 0U;
      this.Background = (uint) (this.Flags & 64) > 0U;
      this.WithMyScore = (uint) (this.Flags & 256) > 0U;
      this.FromPeer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.Id = ObjectUtils.DeserializeVector<int>(br);
      this.RandomId = ObjectUtils.DeserializeVector<long>(br);
      this.ToPeer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.FromPeer, bw);
      ObjectUtils.SerializeObject((object) this.Id, bw);
      ObjectUtils.SerializeObject((object) this.RandomId, bw);
      ObjectUtils.SerializeObject((object) this.ToPeer, bw);
    }

    public override void DeserializeResponse(BinaryReader br) => this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
  }
}
