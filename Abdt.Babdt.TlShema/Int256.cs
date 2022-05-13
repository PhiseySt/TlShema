using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Abdt.Babdt.TlShema
{
    [System.Diagnostics.DebuggerDisplay("{DebuggerDisplay,nq}")]
    [StructLayout(LayoutKind.Explicit, Size = 32, Pack = 1)]
    internal struct Int256 : IComparable<Int256>, IComparable, IEquatable<Int256>, IFormattable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [FieldOffset(0)]
        private ulong _d;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [FieldOffset(8)]
        private ulong _c;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [FieldOffset(16)]
        private ulong _b;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [FieldOffset(32)]
        private ulong _a;
        private const ulong NegativeSignMask = 9223372036854775808;
        public static Int256 Zero = Int256.GetZero();
        public static Int256 MaxValue = Int256.GetMaxValue();
        public static Int256 MinValue = Int256.GetMinValue();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => "0x" + this.ToString("X1");

        private static Int256 GetMaxValue() => new Int256((ulong)long.MaxValue, ulong.MaxValue, ulong.MaxValue, ulong.MaxValue);

        private static Int256 GetMinValue() => -Int256.GetMaxValue();

        private static Int256 GetZero() => new Int256();

        public Int256(byte value)
        {
            this._a = 0UL;
            this._b = 0UL;
            this._c = 0UL;
            this._d = (ulong)value;
        }

        public Int256(bool value)
        {
            this._a = 0UL;
            this._b = 0UL;
            this._c = 0UL;
            this._d = value ? 1UL : 0UL;
        }

        public Int256(char value)
        {
            this._a = 0UL;
            this._b = 0UL;
            this._c = 0UL;
            this._d = (ulong)value;
        }

        public Int256(Decimal value)
        {
            bool flag = value < 0M;
            uint[] u = Decimal.GetBits(value).ConvertAll<int, uint>((Func<int, uint>)(i => (uint)i));
            uint num = u[3] >> 16 & 31U;
            if (num > 0U)
            {
                uint[] q;
                MathUtils.DivModUnsigned(u, new uint[1]
                {
          10U * num
                }, out q, out uint[] _);
                u = q;
            }
            this._a = 0UL;
            this._b = 0UL;
            this._c = (ulong)u[2];
            this._d = (ulong)u[0] | (ulong)u[1] << 32;
            if (!flag)
                return;
            this.Negate();
        }

        public Int256(double value)
          : this((Decimal)value)
        {
        }

        public Int256(float value)
          : this((Decimal)value)
        {
        }

        public Int256(short value)
          : this((int)value)
        {
        }

        public Int256(int value)
          : this((long)value)
        {
        }

        public Int256(long value)
        {
            this._a = this._b = this._c = value < 0L ? ulong.MaxValue : 0UL;
            this._d = (ulong)value;
        }

        public Int256(sbyte value)
          : this((long)value)
        {
        }

        public Int256(ushort value)
        {
            this._a = 0UL;
            this._b = 0UL;
            this._c = 0UL;
            this._d = (ulong)value;
        }

        public Int256(uint value)
        {
            this._a = 0UL;
            this._b = 0UL;
            this._c = 0UL;
            this._d = (ulong)value;
        }

        public Int256(ulong value)
        {
            this._a = 0UL;
            this._b = 0UL;
            this._c = 0UL;
            this._d = value;
        }

        public Int256(Guid value)
        {
            Int256 int256 = value.ToByteArray().ToInt256();
            this._a = int256.A;
            this._b = int256.B;
            this._c = int256.C;
            this._d = int256.D;
        }

        public Int256(Int128 value)
        {
            ulong[] uin64Array = value.ToUIn64Array();
            this._a = this._b = value.Sign < 0 ? ulong.MaxValue : 0UL;
            this._c = uin64Array[1];
            this._d = uin64Array[0];
        }

        public Int256(ulong a, ulong b, ulong c, ulong d)
        {
            this._a = a;
            this._b = b;
            this._c = c;
            this._d = d;
        }

        public Int256(int sign, uint[] ints)
        {
            if (ints == null)
                throw new ArgumentNullException(nameof(ints));
            ulong[] dst = new ulong[4];
            for (int index = 0; index < ints.Length && index < 8; ++index)
                Buffer.BlockCopy((Array)ints[index].ToBytes(new bool?()), 0, (Array)dst, index * 4, 4);
            this._a = dst[3];
            this._b = dst[2];
            this._c = dst[1];
            this._d = dst[0];
            if (sign >= 0 || this._d <= 0UL && this._c <= 0UL && this._b <= 0UL && this._a <= 0UL)
                return;
            this.Negate();
            this._a |= 9223372036854775808UL;
        }

        public ulong A => this._a;

        public ulong B => this._b;

        public ulong C => this._c;

        public ulong D => this._d;

        public int Sign
        {
            get
            {
                if (this._a == 0UL && this._b == 0UL && this._c == 0UL && this._d == 0UL)
                    return 0;
                return ((long)this._a & long.MinValue) != 0L ? -1 : 1;
            }
        }

        public override int GetHashCode() => this._a.GetHashCode() ^ this._b.GetHashCode() ^ this._c.GetHashCode() ^ this._d.GetHashCode();

        public override bool Equals(object obj) => base.Equals(obj);

        public bool Equals(Int256 obj) => (long)this._a == (long)obj._a && (long)this._b == (long)obj._b && (long)this._c == (long)obj._c && (long)this._d == (long)obj._d;

        public override string ToString() => this.ToString((string)null);

        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (formatProvider == null)
                formatProvider = (IFormatProvider)CultureInfo.CurrentCulture;
            if (!string.IsNullOrEmpty(format))
            {
                char ch = format[0];
                switch (ch)
                {
                    case 'D':
                    case 'G':
                    case 'd':
                    case 'g':
                        break;
                    case 'X':
                    case 'x':
                        int result;
                        int.TryParse(format.Substring(1).Trim(), out result);
                        return this.ToBytes(new bool?(false)).ToHexString(ch == 'X', result, trimZeros: true);
                    default:
                        throw new NotSupportedException("Not supported format: " + format);
                }
            }
            return this.ToString((NumberFormatInfo)formatProvider.GetFormat(typeof(NumberFormatInfo)));
        }

        private string ToString(NumberFormatInfo info)
        {
            if (this.Sign == 0)
                return "0";
            StringBuilder stringBuilder = new StringBuilder();
            Int256 divisor = new Int256(10);
            Int256 dividend = this.Sign < 0 ? -this : this;
            do
            {
                Int256 remainder;
                dividend = Int256.DivRem(dividend, divisor, out remainder);
                if (remainder._d > 0UL || dividend.Sign != 0 || stringBuilder.Length == 0)
                    stringBuilder.Insert(0, (char)(48UL + remainder._d));
            }
            while (dividend.Sign != 0);
            string str = stringBuilder.ToString();
            return this.Sign < 0 && str != "0" ? info.NegativeSign + str : str;
        }

        public bool TryConvert(
          Type conversionType,
          IFormatProvider provider,
          bool asLittleEndian,
          out object value)
        {
            if (conversionType == typeof(bool))
            {
                value = (object)(bool)this;
                return true;
            }
            if (conversionType == typeof(byte))
            {
                value = (object)(byte)this;
                return true;
            }
            if (conversionType == typeof(char))
            {
                value = (object)(char)this;
                return true;
            }
            if (conversionType == typeof(Decimal))
            {
                value = (object)(Decimal)this;
                return true;
            }
            if (conversionType == typeof(double))
            {
                value = (object)(double)this;
                return true;
            }
            if (conversionType == typeof(short))
            {
                value = (object)(short)this;
                return true;
            }
            if (conversionType == typeof(int))
            {
                value = (object)(int)this;
                return true;
            }
            if (conversionType == typeof(long))
            {
                value = (object)(long)this;
                return true;
            }
            if (conversionType == typeof(sbyte))
            {
                value = (object)(sbyte)(short)this;
                return true;
            }
            if (conversionType == typeof(float))
            {
                value = (object)(float)this;
                return true;
            }
            if (conversionType == typeof(string))
            {
                value = (object)this.ToString((string)null, provider);
                return true;
            }
            if (conversionType == typeof(ushort))
            {
                value = (object)(ushort)this;
                return true;
            }
            if (conversionType == typeof(uint))
            {
                value = (object)(uint)this;
                return true;
            }
            if (conversionType == typeof(ulong))
            {
                value = (object)(ulong)this;
                return true;
            }
            if (conversionType == typeof(byte[]))
            {
                value = (object)this.ToBytes(new bool?(asLittleEndian));
                return true;
            }
            if (conversionType == typeof(Guid))
            {
                value = (object)new Guid(this.ToBytes(new bool?(asLittleEndian)));
                return true;
            }
            if (conversionType == typeof(Int128))
            {
                value = (object)(Int128)this;
                return true;
            }
            value = (object)null;
            return false;
        }

        public static Int256 Parse(string value) => Int256.Parse(value, NumberStyles.Integer, (IFormatProvider)NumberFormatInfo.CurrentInfo);

        public static Int256 Parse(string value, NumberStyles style) => Int256.Parse(value, style, (IFormatProvider)NumberFormatInfo.CurrentInfo);

        public static Int256 Parse(string value, IFormatProvider provider) => Int256.Parse(value, NumberStyles.Integer, (IFormatProvider)NumberFormatInfo.GetInstance(provider));

        public static Int256 Parse(string value, NumberStyles style, IFormatProvider provider)
        {
            Int256 result;
            if (!Int256.TryParse(value, style, provider, out result))
                throw new ArgumentException((string)null, nameof(value));
            return result;
        }

        public static bool TryParse(string value, out Int256 result) => Int256.TryParse(value, NumberStyles.Integer, (IFormatProvider)NumberFormatInfo.CurrentInfo, out result);

        public static bool TryParse(
          string value,
          NumberStyles style,
          IFormatProvider provider,
          out Int256 result)
        {
            result = Int256.Zero;
            if (string.IsNullOrEmpty(value))
                return false;
            if (value.StartsWith("x", StringComparison.OrdinalIgnoreCase))
            {
                style |= NumberStyles.AllowHexSpecifier;
                value = value.Substring(1);
            }
            else if (value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                style |= NumberStyles.AllowHexSpecifier;
                value = value.Substring(2);
            }
            return (style & NumberStyles.AllowHexSpecifier) == NumberStyles.AllowHexSpecifier ? Int256.TryParseHex(value, out result) : Int256.TryParseNum(value, out result);
        }

        private static bool TryParseHex(string value, out Int256 result)
        {
            if (value.Length > 64)
                throw new OverflowException();
            result = Int256.Zero;
            int num1 = 0;
            for (int index = value.Length - 1; index >= 0; --index)
            {
                char ch = value[index];
                ulong num2;
                if (ch >= '0' && ch <= '9')
                    num2 = (ulong)((int)ch - 48);
                else if (ch >= 'A' && ch <= 'F')
                {
                    num2 = (ulong)((int)ch - 65 + 10);
                }
                else
                {
                    if (ch < 'a' || ch > 'f')
                        return false;
                    num2 = (ulong)((int)ch - 97 + 10);
                }
                if (num1 < 64)
                    result._d |= num2 << num1;
                else if (num1 < 128)
                    result._c |= num2 << num1;
                else if (num1 < 192)
                    result._b |= num2 << num1;
                else if (num1 < 256)
                    result._a |= num2 << num1;
                num1 += 4;
            }
            return true;
        }

        private static bool TryParseNum(string value, out Int256 result)
        {
            result = Int256.Zero;
            foreach (char ch in value)
            {
                switch (ch)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        byte num = (byte)((uint)ch - 48U);
                        result = (Int256)10 * result;
                        result += (Int256)num;
                        continue;
                    default:
                        return false;
                }
            }
            return true;
        }

        public object ToType(Type conversionType, IFormatProvider provider, bool asLittleEndian)
        {
            object type;
            if (this.TryConvert(conversionType, provider, asLittleEndian, out type))
                return type;
            throw new InvalidCastException();
        }

        int IComparable.CompareTo(object obj) => Int256.Compare(this, obj);

        public static int Compare(Int256 left, object right)
        {
            switch (right)
            {
                case Int256 right1:
                    return Int256.Compare(left, right1);
                case bool flag:
                    return Int256.Compare(left, new Int256(flag));
                case byte num1:
                    return Int256.Compare(left, new Int256(num1));
                case char ch:
                    return Int256.Compare(left, new Int256(ch));
                case Decimal num2:
                    return Int256.Compare(left, new Int256(num2));
                case double num3:
                    return Int256.Compare(left, new Int256(num3));
                case short num4:
                    return Int256.Compare(left, new Int256(num4));
                case int num5:
                    return Int256.Compare(left, new Int256(num5));
                case long num6:
                    return Int256.Compare(left, new Int256(num6));
                case sbyte num7:
                    return Int256.Compare(left, new Int256(num7));
                case float num8:
                    return Int256.Compare(left, new Int256(num8));
                case ushort num9:
                    return Int256.Compare(left, new Int256(num9));
                case uint num10:
                    return Int256.Compare(left, new Int256(num10));
                case ulong num11:
                    return Int256.Compare(left, new Int256(num11));
                case byte[] bytes when bytes.Length == 32:
                    return Int256.Compare(left, bytes.ToInt256());
                case Guid guid:
                    return Int256.Compare(left, new Int256(guid));
                default:
                    throw new ArgumentException();
            }
        }

        public static int Compare(Int256 left, Int256 right)
        {
            int sign1 = left.Sign;
            int sign2 = right.Sign;
            if (sign1 == 0 && sign2 == 0)
                return 0;
            if (sign1 >= 0 && sign2 < 0)
                return 1;
            if (sign1 < 0 && sign2 >= 0)
                return -1;
            if ((long)left._a != (long)right._a)
                return left._a.CompareTo(right._a);
            if ((long)left._b != (long)right._b)
                return left._b.CompareTo(right._b);
            return (long)left._c != (long)right._c ? left._c.CompareTo(right._c) : left._d.CompareTo(right._d);
        }

        public int CompareTo(Int256 value) => Int256.Compare(this, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Not()
        {
            this._a = ~this._a;
            this._b = ~this._b;
            this._c = ~this._c;
            this._d = ~this._d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Negate()
        {
            this.Not();
            this = this++;
        }

        public static Int256 Negate(Int256 value)
        {
            value.Negate();
            return value;
        }

        public Int256 ToAbs() => Int256.Abs(this);

        public static Int256 Abs(Int256 value) => value.Sign < 0 ? -value : value;

        public static Int256 Add(Int256 left, Int256 right) => left + right;

        public static Int256 Subtract(Int256 left, Int256 right) => left - right;

        public static Int256 Divide(Int256 dividend, Int256 divisor) => Int256.DivRem(dividend, divisor, out Int256 _);

        public static Int256 Remainder(Int256 dividend, Int256 divisor)
        {
            Int256 remainder;
            Int256.DivRem(dividend, divisor, out remainder);
            return remainder;
        }

        public static Int256 DivRem(Int256 dividend, Int256 divisor, out Int256 remainder)
        {
            if (divisor == (Int256)0)
                throw new DivideByZeroException();
            int sign1 = dividend.Sign;
            dividend = sign1 < 0 ? -dividend : dividend;
            int sign2 = divisor.Sign;
            divisor = sign2 < 0 ? -divisor : divisor;
            uint[] q;
            uint[] r;
            MathUtils.DivModUnsigned(dividend.ToUIn32Array(), divisor.ToUIn32Array(), out q, out r);
            remainder = new Int256(1, r);
            return new Int256(sign1 * sign2, q);
        }

        public ulong[] ToUIn64Array() => new ulong[4]
        {
      this._d,
      this._c,
      this._b,
      this._a
        };

        public uint[] ToUIn32Array()
        {
            uint[] dst = new uint[8];
            Buffer.BlockCopy((Array)this.ToUIn64Array(), 0, (Array)dst, 0, 32);
            return dst;
        }

        public static Int256 Multiply(Int256 left, Int256 right)
        {
            int sign1 = left.Sign;
            left = sign1 < 0 ? -left : left;
            int sign2 = right.Sign;
            right = sign2 < 0 ? -right : right;
            uint[] uin32Array1 = left.ToUIn32Array();
            uint[] uin32Array2 = right.ToUIn32Array();
            uint[] ints = new uint[16];
            for (int index1 = 0; index1 < uin32Array1.Length; ++index1)
            {
                int index2 = index1;
                ulong num1 = 0;
                foreach (uint num2 in uin32Array2)
                {
                    ulong num3 = num1 + (ulong)uin32Array1[index1] * (ulong)num2 + (ulong)ints[index2];
                    ints[index2++] = (uint)num3;
                    num1 = num3 >> 32;
                }
                ulong num4;
                for (; num1 != 0UL; num1 = num4 >> 32)
                {
                    num4 = num1 + (ulong)ints[index2];
                    ints[index2++] = (uint)num4;
                }
            }
            return new Int256(sign1 * sign2, ints);
        }

        public static implicit operator Int256(bool value) => new Int256(value);

        public static implicit operator Int256(byte value) => new Int256(value);

        public static implicit operator Int256(char value) => new Int256(value);

        public static explicit operator Int256(Decimal value) => new Int256(value);

        public static explicit operator Int256(double value) => new Int256(value);

        public static implicit operator Int256(short value) => new Int256(value);

        public static implicit operator Int256(int value) => new Int256(value);

        public static implicit operator Int256(long value) => new Int256(value);

        public static implicit operator Int256(sbyte value) => new Int256(value);

        public static explicit operator Int256(float value) => new Int256(value);

        public static implicit operator Int256(ushort value) => new Int256(value);

        public static implicit operator Int256(uint value) => new Int256(value);

        public static implicit operator Int256(ulong value) => new Int256(value);

        public static explicit operator bool(Int256 value) => (uint)value.Sign > 0U;

        public static explicit operator byte(Int256 value)
        {
            if (value.Sign == 0)
                return 0;
            return !(value < (Int256)(byte)0) && !(value > (Int256)byte.MaxValue) ? (byte)value._d : throw new OverflowException();
        }

        public static explicit operator char(Int256 value)
        {
            if (value.Sign == 0)
                return char.MinValue;
            return !(value < (Int256)char.MinValue) && !(value > (Int256)char.MaxValue) ? (char)value._d : throw new OverflowException();
        }

        public static explicit operator Decimal(Int256 value)
        {
            if (value.Sign == 0)
                return 0M;
            if (value < (Int256)Decimal.MinValue || value > (Int256)Decimal.MaxValue)
                throw new OverflowException();
            return new Decimal((int)((long)value._d & (long)uint.MaxValue), (int)(value._d >> 32), (int)((long)value._c & (long)uint.MaxValue), value.Sign < 0, (byte)0);
        }

        public static explicit operator double(Int256 value)
        {
            if (value.Sign == 0)
                return 0.0;
            NumberFormatInfo numberFormat = CultureInfo.InvariantCulture.NumberFormat;
            double result;
            if (!double.TryParse(value.ToString(numberFormat), NumberStyles.Number, (IFormatProvider)numberFormat, out result))
                throw new OverflowException();
            return result;
        }

        public static explicit operator float(Int256 value)
        {
            if (value.Sign == 0)
                return 0.0f;
            NumberFormatInfo numberFormat = CultureInfo.InvariantCulture.NumberFormat;
            float result;
            if (!float.TryParse(value.ToString(numberFormat), NumberStyles.Number, (IFormatProvider)numberFormat, out result))
                throw new OverflowException();
            return result;
        }

        public static explicit operator short(Int256 value)
        {
            if (value.Sign == 0)
                return 0;
            return !(value < (Int256)short.MinValue) && !(value > (Int256)short.MaxValue) ? (short)value._d : throw new OverflowException();
        }

        public static explicit operator int(Int256 value)
        {
            if (value.Sign == 0)
                return 0;
            return !(value < (Int256)int.MinValue) && !(value > (Int256)int.MaxValue) ? (int)value._d : throw new OverflowException();
        }

        public static explicit operator long(Int256 value)
        {
            if (value.Sign == 0)
                return 0;
            return !(value < (Int256)long.MinValue) && !(value > (Int256)long.MaxValue) ? (long)value._d : throw new OverflowException();
        }

        public static explicit operator uint(Int256 value)
        {
            if (value.Sign == 0)
                return 0;
            return !(value < (Int256)0U) && !(value > (Int256)uint.MaxValue) ? (uint)value._d : throw new OverflowException();
        }

        public static explicit operator ushort(Int256 value)
        {
            if (value.Sign == 0)
                return 0;
            return !(value < (Int256)(ushort)0) && !(value > (Int256)ushort.MaxValue) ? (ushort)value._d : throw new OverflowException();
        }

        public static explicit operator ulong(Int256 value) => !(value < (Int256)(ushort)0) && !(value > (Int256)ushort.MaxValue) ? value._d : throw new OverflowException();

        public static bool operator >(Int256 left, Int256 right) => Int256.Compare(left, right) > 0;

        public static bool operator <(Int256 left, Int256 right) => Int256.Compare(left, right) < 0;

        public static bool operator >=(Int256 left, Int256 right) => Int256.Compare(left, right) >= 0;

        public static bool operator <=(Int256 left, Int256 right) => Int256.Compare(left, right) <= 0;

        public static bool operator !=(Int256 left, Int256 right) => (uint)Int256.Compare(left, right) > 0U;

        public static bool operator ==(Int256 left, Int256 right) => Int256.Compare(left, right) == 0;

        public static Int256 operator +(Int256 value) => value;

        public static Int256 operator -(Int256 value) => Int256.Negate(value);

        public static Int256 operator +(Int256 left, Int256 right)
        {
            left._a += right._a;
            left._b += right._b;
            if (left._b < right._b)
                ++left._a;
            left._c += right._c;
            if (left._c < right._c)
            {
                ++left._b;
                if (left._b < left._b - 1UL)
                    ++left._a;
            }
            left._d += right._d;
            if (left._d < right._d)
            {
                ++left._c;
                if (left._c < left._c - 1UL)
                {
                    ++left._b;
                    if (left._b < left._b - 1UL)
                        ++left._a;
                }
            }
            return left;
        }

        public static Int256 operator -(Int256 left, Int256 right) => left + -right;

        public static Int256 operator %(Int256 dividend, Int256 divisor) => Int256.Remainder(dividend, divisor);

        public static Int256 operator /(Int256 dividend, Int256 divisor) => Int256.Divide(dividend, divisor);

        public static Int256 operator *(Int256 left, Int256 right) => Int256.Multiply(left, right);

        public static Int256 operator >>(Int256 value, int shift)
        {
            if (shift == 0)
                return value;
            ulong[] numArray = MathUtils.ShiftRightSigned(value.ToUIn64Array(), shift);
            value._a = numArray[3];
            value._b = numArray[2];
            value._c = numArray[1];
            value._d = numArray[0];
            return value;
        }

        public static Int256 operator <<(Int256 value, int shift)
        {
            if (shift == 0)
                return value;
            ulong[] numArray = MathUtils.ShiftLeft(value.ToUIn64Array(), shift);
            value._a = numArray[3];
            value._b = numArray[2];
            value._c = numArray[1];
            value._d = numArray[0];
            return value;
        }

        public static Int256 operator |(Int256 left, Int256 right)
        {
            if (left == (Int256)0)
                return right;
            if (right == (Int256)0)
                return left;
            left._a |= right._a;
            left._b |= right._b;
            left._c |= right._c;
            left._d |= right._d;
            return left;
        }

        public static Int256 operator &(Int256 left, Int256 right)
        {
            if (left == (Int256)0 || right == (Int256)0)
                return Int256.Zero;
            left._a &= right._a;
            left._b &= right._b;
            left._c &= right._c;
            left._d &= right._d;
            return left;
        }

        public static Int256 operator ~(Int256 value) => new Int256(~value._a, ~value._b, ~value._c, ~value._d);

        public static Int256 operator ++(Int256 value) => value + (Int256)1;

        public static Int256 operator --(Int256 value) => value - (Int256)1;
    }
}
