﻿using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-1584933265)]
  public class TLSendMessageRecordVideoAction : TLAbsSendMessageAction
  {
    public override int Constructor => -1584933265;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
