using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(393186209)]
  public class TLSendMessageGeoLocationAction : TLAbsSendMessageAction
  {
    public override int Constructor => 393186209;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
