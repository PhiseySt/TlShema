using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-378127636)]
  public class TLSendMessageUploadVideoAction : TLAbsSendMessageAction
  {
    public override int Constructor => -378127636;

    public int Progress { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Progress = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Progress);
    }
  }
}
