﻿using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1830677896)]
  public class TLPeerNotifyEventsAll : TLAbsPeerNotifyEvents
  {
    public override int Constructor => 1830677896;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
