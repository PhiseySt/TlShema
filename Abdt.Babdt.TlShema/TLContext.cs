using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Abdt.Babdt.TlShema
{
  public static class TLContext
  {
    private static Dictionary<int, Type> Types;

    static TLContext()
    {
      Type[] types = typeof (TLContext).Assembly.GetTypes();
      TLContext.Types = new Dictionary<int, Type>();
      Func<Type, bool> predicate = (Func<Type, bool>) (t => t.IsClass);
      TLContext.Types = ((IEnumerable<Type>) types).Where<Type>(predicate).Where<Type>((Func<Type, bool>) (t => t.IsSubclassOf(typeof (TLObject)))).Where<Type>((Func<Type, bool>) (t => t.GetCustomAttribute(typeof (TLObjectAttribute)) != null)).ToDictionary<Type, int, Type>((Func<Type, int>) (x => ((TLObjectAttribute) x.GetCustomAttribute(typeof (TLObjectAttribute))).Constructor), (Func<Type, Type>) (x => x));
    }

    public static Type getType(int Constructor) => TLContext.Types[Constructor];
  }
}
