using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-718310409)]
  public class TLSendMessageRecordAudioAction : TLAbsSendMessageAction
  {
    public override int Constructor => -718310409;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
