﻿using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(1959820384)]
  public class TLNotifyAll : TLAbsNotifyPeer
  {
    public override int Constructor => 1959820384;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
