﻿using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(-265263912)]
  public class TLInputPeerNotifyEventsEmpty : TLAbsInputPeerNotifyEvents
  {
    public override int Constructor => -265263912;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
