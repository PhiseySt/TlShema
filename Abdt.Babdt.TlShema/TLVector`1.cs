using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Abdt.Babdt.TlShema
{
  public class TLVector<T> : TLObject, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
  {
    [TLObject(481674261)]
    private List<T> lists = new List<T>();

    public T this[int index]
    {
      get => this.lists[index];
      set => this.lists[index] = value;
    }

    public override int Constructor => 481674261;

    public int Count => this.lists.Count;

    public bool IsReadOnly => ((ICollection<T>) this.lists).IsReadOnly;

    public void Add(T item) => this.lists.Add(item);

    public void Clear() => this.lists.Clear();

    public bool Contains(T item) => this.lists.Contains(item);

    public void CopyTo(T[] array, int arrayIndex) => this.lists.CopyTo(array, arrayIndex);

    public override void DeserializeBody(BinaryReader br)
    {
      int num = br.ReadInt32();
      for (int index = 0; index < num; ++index)
      {
        if (typeof (T) == typeof (int))
          this.lists.Add((T) Convert.ChangeType((object) br.ReadInt32(), typeof (T)));
        else if (typeof (T) == typeof (long))
          this.lists.Add((T) Convert.ChangeType((object) br.ReadInt64(), typeof (T)));
        else if (typeof (T) == typeof (string))
          this.lists.Add((T) Convert.ChangeType((object) StringUtil.Deserialize(br), typeof (T)));
        else if (typeof (T) == typeof (double))
          this.lists.Add((T) Convert.ChangeType((object) br.ReadDouble(), typeof (T)));
        else if (typeof (T).BaseType == typeof (TLObject))
        {
          Type type = TLContext.getType(br.ReadInt32());
          object instance = Activator.CreateInstance(type);
          type.GetMethod(nameof (DeserializeBody)).Invoke(instance, new object[1]
          {
            (object) br
          });
          this.lists.Add((T) Convert.ChangeType(instance, type));
        }
      }
    }

    public IEnumerator<T> GetEnumerator() => (IEnumerator<T>) this.lists.GetEnumerator();

    public int IndexOf(T item) => this.lists.IndexOf(item);

    public void Insert(int index, T item) => this.lists.Insert(index, item);

    public bool Remove(T item) => this.lists.Remove(item);

    public void RemoveAt(int index) => this.lists.RemoveAt(index);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.lists.Count<T>());
      foreach (T list in this.lists)
      {
        if (typeof (T) == typeof (int))
        {
          int num = (int) Convert.ChangeType((object) list, typeof (int));
          bw.Write(num);
        }
        else if (typeof (T) == typeof (long))
        {
          long num = (long) Convert.ChangeType((object) list, typeof (long));
          bw.Write(num);
        }
        else if (typeof (T) == typeof (string))
          StringUtil.Serialize((string) Convert.ChangeType((object) list, typeof (string)), bw);
        else if (typeof (T) == typeof (double))
        {
          double num = (double) Convert.ChangeType((object) list, typeof (double));
          bw.Write(num);
        }
        else if (typeof (T).BaseType == typeof (TLObject))
          ((TLObject) (object) list).SerializeBody(bw);
      }
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.lists.GetEnumerator();
  }
}
