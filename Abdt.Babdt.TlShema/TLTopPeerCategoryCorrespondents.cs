﻿using System.IO;

namespace Abdt.Babdt.TlShema
{
  [TLObject(104314861)]
  public class TLTopPeerCategoryCorrespondents : TLAbsTopPeerCategory
  {
    public override int Constructor => 104314861;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
