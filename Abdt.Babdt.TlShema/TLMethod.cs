using System;
using System.IO;

namespace Abdt.Babdt.TlShema
{
  public abstract class TLMethod : TLObject
  {
    public abstract void DeserializeResponse(BinaryReader stream);

    public long MessageId { get; set; }

    public int Sequence { get; set; }

    public bool Dirty { get; set; }

    public bool Sended { get; private set; }

    public DateTime SendTime { get; private set; }

    public bool ConfirmReceived { get; set; }

    public virtual bool Confirmed { get; } = true;

    public virtual bool Responded { get; }

    public virtual void OnSendSuccess()
    {
      this.SendTime = DateTime.Now;
      this.Sended = true;
    }

    public virtual void OnConfirm() => this.ConfirmReceived = true;

    public bool NeedResend
    {
      get
      {
        if (this.Dirty)
          return true;
        return this.Confirmed && !this.ConfirmReceived && DateTime.Now - this.SendTime > TimeSpan.FromSeconds(3.0);
      }
    }
  }
}
