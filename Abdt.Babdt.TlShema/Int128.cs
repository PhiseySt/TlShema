using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Abdt.Babdt.TlShema
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [StructLayout(LayoutKind.Explicit, Size = 16, Pack = 1)]
    internal struct Int128 : IComparable<Int128>, IComparable, IEquatable<Int128>, IFormattable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [FieldOffset(0)]
        private ulong _lo;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [FieldOffset(8)]
        private ulong _hi;
        private const ulong NegativeSignMask = 9223372036854775808;
        public static Int128 Zero = Int128.GetZero();
        public static Int128 MaxValue = Int128.GetMaxValue();
        public static Int128 MinValue = Int128.GetMinValue();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => "0x" + this.ToString("X1");

        private static Int128 GetMaxValue() => new Int128((ulong)long.MaxValue, ulong.MaxValue);

        private static Int128 GetMinValue() => -Int128.GetMaxValue();

        private static Int128 GetZero() => new Int128();

        public Int128(byte value)
        {
            this._hi = 0UL;
            this._lo = (ulong)value;
        }

        public Int128(bool value)
        {
            this._hi = 0UL;
            this._lo = value ? 1UL : 0UL;
        }

        public Int128(char value)
        {
            this._hi = 0UL;
            this._lo = (ulong)value;
        }

        public Int128(Decimal value)
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
            this._hi = (ulong)u[2];
            this._lo = (ulong)u[0] | (ulong)u[1] << 32;
            if (!flag)
                return;
            this.Negate();
        }

        public Int128(double value)
          : this((Decimal)value)
        {
        }

        public Int128(float value)
          : this((Decimal)value)
        {
        }

        public Int128(short value)
          : this((int)value)
        {
        }

        public Int128(int value)
          : this((long)value)
        {
        }

        public Int128(long value)
        {
            this._hi = value < 0L ? ulong.MaxValue : 0UL;
            this._lo = (ulong)value;
        }

        public Int128(sbyte value)
          : this((long)value)
        {
        }

        public Int128(ushort value)
        {
            this._hi = 0UL;
            this._lo = (ulong)value;
        }

        public Int128(uint value)
        {
            this._hi = 0UL;
            this._lo = (ulong)value;
        }

        public Int128(ulong value)
        {
            this._hi = 0UL;
            this._lo = value;
        }

        public Int128(Guid value)
        {
            Int128 int128 = value.ToByteArray().ToInt128();
            this._hi = int128.High;
            this._lo = int128.Low;
        }

        public Int128(Int256 value)
        {
            ulong[] uin64Array = value.ToUIn64Array();
            this._hi = uin64Array[1];
            this._lo = uin64Array[0];
        }

        public Int128(ulong hi, ulong lo)
        {
            this._hi = hi;
            this._lo = lo;
        }

        public Int128(int sign, uint[] ints)
        {
            if (ints == null)
                throw new ArgumentNullException(nameof(ints));
            ulong[] dst = new ulong[2];
            for (int index = 0; index < ints.Length && index < 4; ++index)
                Buffer.BlockCopy((Array)ints[index].ToBytes(new bool?()), 0, (Array)dst, index * 4, 4);
            this._hi = dst[1];
            this._lo = dst[0];
            if (sign >= 0 || this._hi <= 0UL && this._lo <= 0UL)
                return;
            this.Negate();
            this._hi |= 9223372036854775808UL;
        }

        public ulong High => this._hi;

        public ulong Low => this._lo;

        public int Sign
        {
            get
            {
                if (this._hi == 0UL && this._lo == 0UL)
                    return 0;
                return ((long)this._hi & long.MinValue) != 0L ? -1 : 1;
            }
        }

        public override int GetHashCode() => this._hi.GetHashCode() ^ this._lo.GetHashCode();

        public override bool Equals(object obj) => base.Equals(obj);

        public bool Equals(Int128 obj) => (long)this._hi == (long)obj._hi && (long)this._lo == (long)obj._lo;

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
            Int128 divisor = new Int128(10);
            Int128 dividend = this.Sign < 0 ? -this : this;
            do
            {
                Int128 remainder;
                dividend = Int128.DivRem(dividend, divisor, out remainder);
                if (remainder._lo > 0UL || dividend.Sign != 0 || stringBuilder.Length == 0)
                    stringBuilder.Insert(0, (char)(48UL + remainder._lo));
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
            if (conversionType == typeof(Int256))
            {
                value = (object)(Int256)this;
                return true;
            }
            value = (object)null;
            return false;
        }

        public static Int128 Parse(string value) => Int128.Parse(value, NumberStyles.Integer, (IFormatProvider)NumberFormatInfo.CurrentInfo);

        public static Int128 Parse(string value, NumberStyles style) => Int128.Parse(value, style, (IFormatProvider)NumberFormatInfo.CurrentInfo);

        public static Int128 Parse(string value, IFormatProvider provider) => Int128.Parse(value, NumberStyles.Integer, (IFormatProvider)NumberFormatInfo.GetInstance(provider));

        public static Int128 Parse(string value, NumberStyles style, IFormatProvider provider)
        {
            Int128 result;
            if (!Int128.TryParse(value, style, provider, out result))
                throw new ArgumentException((string)null, nameof(value));
            return result;
        }

        public static bool TryParse(string value, out Int128 result) => Int128.TryParse(value, NumberStyles.Integer, (IFormatProvider)NumberFormatInfo.CurrentInfo, out result);

        public static bool TryParse(
          string value,
          NumberStyles style,
          IFormatProvider provider,
          out Int128 result)
        {
            result = Int128.Zero;
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
            return (style & NumberStyles.AllowHexSpecifier) == NumberStyles.AllowHexSpecifier ? Int128.TryParseHex(value, out result) : Int128.TryParseNum(value, out result);
        }

        private static bool TryParseHex(string value, out Int128 result)
        {
            if (value.Length > 32)
                throw new OverflowException();
            result = Int128.Zero;
            bool flag = false;
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
                if (flag)
                {
                    result._hi |= num2 << num1;
                    num1 += 4;
                }
                else
                {
                    result._lo |= num2 << num1;
                    num1 += 4;
                    if (num1 == 64)
                    {
                        num1 = 0;
                        flag = true;
                    }
                }
            }
            return true;
        }

        private static bool TryParseNum(string value, out Int128 result)
        {
            result = Int128.Zero;
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
                        result = (Int128)10 * result;
                        result += (Int128)num;
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

        int IComparable.CompareTo(object obj) => Int128.Compare(this, obj);

        public static int Compare(Int128 left, object right)
        {
            switch (right)
            {
                case Int128 right1:
                    return Int128.Compare(left, right1);
                case bool flag:
                    return Int128.Compare(left, new Int128(flag));
                case byte num1:
                    return Int128.Compare(left, new Int128(num1));
                case char ch:
                    return Int128.Compare(left, new Int128(ch));
                case Decimal num2:
                    return Int128.Compare(left, new Int128(num2));
                case double num3:
                    return Int128.Compare(left, new Int128(num3));
                case short num4:
                    return Int128.Compare(left, new Int128(num4));
                case int num5:
                    return Int128.Compare(left, new Int128(num5));
                case long num6:
                    return Int128.Compare(left, new Int128(num6));
                case sbyte num7:
                    return Int128.Compare(left, new Int128(num7));
                case float num8:
                    return Int128.Compare(left, new Int128(num8));
                case ushort num9:
                    return Int128.Compare(left, new Int128(num9));
                case uint num10:
                    return Int128.Compare(left, new Int128(num10));
                case ulong num11:
                    return Int128.Compare(left, new Int128(num11));
                case byte[] bytes when bytes.Length == 16:
                    return Int128.Compare(left, bytes.ToInt128());
                case Guid guid:
                    return Int128.Compare(left, new Int128(guid));
                default:
                    throw new ArgumentException();
            }
        }

        public static int Compare(Int128 left, Int128 right)
        {
            int sign1 = left.Sign;
            int sign2 = right.Sign;
            if (sign1 == 0 && sign2 == 0)
                return 0;
            if (sign1 >= 0 && sign2 < 0)
                return 1;
            if (sign1 < 0 && sign2 >= 0)
                return -1;
            return (long)left._hi != (long)right._hi ? left._hi.CompareTo(right._hi) : left._lo.CompareTo(right._lo);
        }

        public int CompareTo(Int128 value) => Int128.Compare(this, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Not()
        {
            this._hi = ~this._hi;
            this._lo = ~this._lo;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Negate()
        {
            this.Not();
            this = this++;
        }

        public static Int128 Negate(Int128 value)
        {
            value.Negate();
            return value;
        }

        public Int128 ToAbs() => Int128.Abs(this);

        public static Int128 Abs(Int128 value) => value.Sign < 0 ? -value : value;

        public static Int128 Add(Int128 left, Int128 right) => left + right;

        public static Int128 Subtract(Int128 left, Int128 right) => left - right;

        public static Int128 Divide(Int128 dividend, Int128 divisor) => Int128.DivRem(dividend, divisor, out Int128 _);

        public static Int128 DivRem(Int128 dividend, Int128 divisor, out Int128 remainder)
        {
            if (divisor == (Int128)0)
                throw new DivideByZeroException();
            int sign1 = dividend.Sign;
            dividend = sign1 < 0 ? -dividend : dividend;
            int sign2 = divisor.Sign;
            divisor = sign2 < 0 ? -divisor : divisor;
            uint[] q;
            uint[] r;
            MathUtils.DivModUnsigned(dividend.ToUIn32Array(), divisor.ToUIn32Array(), out q, out r);
            remainder = new Int128(1, r);
            return new Int128(sign1 * sign2, q);
        }

        public static Int128 Remainder(Int128 dividend, Int128 divisor)
        {
            Int128 remainder;
            Int128.DivRem(dividend, divisor, out remainder);
            return remainder;
        }

        public ulong[] ToUIn64Array() => new ulong[2]
        {
      this._lo,
      this._hi
        };

        public uint[] ToUIn32Array()
        {
            uint[] dst = new uint[4];
            Buffer.BlockCopy((Array)this.ToUIn64Array(), 0, (Array)dst, 0, 16);
            return dst;
        }

        public static Int128 Multiply(Int128 left, Int128 right)
        {
            int sign1 = left.Sign;
            left = sign1 < 0 ? -left : left;
            int sign2 = right.Sign;
            right = sign2 < 0 ? -right : right;
            uint[] uin32Array1 = left.ToUIn32Array();
            uint[] uin32Array2 = right.ToUIn32Array();
            uint[] ints = new uint[8];
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
            return new Int128(sign1 * sign2, ints);
        }

        public static implicit operator Int128(bool value) => new Int128(value);

        public static implicit operator Int128(byte value) => new Int128(value);

        public static implicit operator Int128(char value) => new Int128(value);

        public static explicit operator Int128(Decimal value) => new Int128(value);

        public static explicit operator Int128(double value) => new Int128(value);

        public static implicit operator Int128(short value) => new Int128(value);

        public static implicit operator Int128(int value) => new Int128(value);

        public static implicit operator Int128(long value) => new Int128(value);

        public static implicit operator Int128(sbyte value) => new Int128(value);

        public static explicit operator Int128(float value) => new Int128(value);

        public static implicit operator Int128(ushort value) => new Int128(value);

        public static implicit operator Int128(uint value) => new Int128(value);

        public static implicit operator Int128(ulong value) => new Int128(value);

        public static explicit operator Int128(Int256 value) => new Int128(value);

        public static explicit operator Int256(Int128 value) => new Int256(value);

        public static explicit operator bool(Int128 value) => (uint)value.Sign > 0U;

        public static explicit operator byte(Int128 value)
        {
            if (value.Sign == 0)
                return 0;
            return !(value < (Int128)(byte)0) && !(value > (Int128)byte.MaxValue) ? (byte)value._lo : throw new OverflowException();
        }

        public static explicit operator char(Int128 value)
        {
            if (value.Sign == 0)
                return char.MinValue;
            return !(value < (Int128)char.MinValue) && !(value > (Int128)char.MaxValue) ? (char)value._lo : throw new OverflowException();
        }

        public static explicit operator Decimal(Int128 value) => value.Sign == 0 ? 0M : new Decimal((int)((long)value._lo & (long)uint.MaxValue), (int)(value._lo >> 32), (int)((long)value._hi & (long)uint.MaxValue), value.Sign < 0, (byte)0);

        public static explicit operator double(Int128 value)
        {
            if (value.Sign == 0)
                return 0.0;
            NumberFormatInfo numberFormat = CultureInfo.InvariantCulture.NumberFormat;
            double result;
            if (!double.TryParse(value.ToString(numberFormat), NumberStyles.Number, (IFormatProvider)numberFormat, out result))
                throw new OverflowException();
            return result;
        }

        public static explicit operator float(Int128 value)
        {
            if (value.Sign == 0)
                return 0.0f;
            NumberFormatInfo numberFormat = CultureInfo.InvariantCulture.NumberFormat;
            float result;
            if (!float.TryParse(value.ToString(numberFormat), NumberStyles.Number, (IFormatProvider)numberFormat, out result))
                throw new OverflowException();
            return result;
        }

        public static explicit operator short(Int128 value)
        {
            if (value.Sign == 0)
                return 0;
            return !(value < (Int128)short.MinValue) && !(value > (Int128)short.MaxValue) ? (short)value._lo : throw new OverflowException();
        }

        public static explicit operator int(Int128 value)
        {
            if (value.Sign == 0)
                return 0;
            return !(value < (Int128)int.MinValue) && !(value > (Int128)int.MaxValue) ? (int)value._lo : throw new OverflowException();
        }

        public static explicit operator long(Int128 value)
        {
            if (value.Sign == 0)
                return 0;
            return !(value < (Int128)long.MinValue) && !(value > (Int128)long.MaxValue) ? (long)value._lo : throw new OverflowException();
        }

        public static explicit operator uint(Int128 value)
        {
            if (value.Sign == 0)
                return 0;
            return !(value < (Int128)0U) && !(value > (Int128)uint.MaxValue) ? (uint)value._lo : throw new OverflowException();
        }

        public static explicit operator ushort(Int128 value)
        {
            if (value.Sign == 0)
                return 0;
            return !(value < (Int128)(ushort)0) && !(value > (Int128)ushort.MaxValue) ? (ushort)value._lo : throw new OverflowException();
        }

        public static explicit operator ulong(Int128 value)
        {
            if (value.Sign == 0)
                return 0;
            return !(value < (Int128)0UL) && !(value > (Int128)ulong.MaxValue) ? value._lo : throw new OverflowException();
        }

        public static bool operator >(Int128 left, Int128 right) => Int128.Compare(left, right) > 0;

        public static bool operator <(Int128 left, Int128 right) => Int128.Compare(left, right) < 0;

        public static bool operator >=(Int128 left, Int128 right) => Int128.Compare(left, right) >= 0;

        public static bool operator <=(Int128 left, Int128 right) => Int128.Compare(left, right) <= 0;

        public static bool operator !=(Int128 left, Int128 right) => (uint)Int128.Compare(left, right) > 0U;

        public static bool operator ==(Int128 left, Int128 right) => Int128.Compare(left, right) == 0;

        public static Int128 operator +(Int128 value) => value;

        public static Int128 operator -(Int128 value) => Int128.Negate(value);

        public static Int128 operator +(Int128 left, Int128 right)
        {
            left._hi += right._hi;
            left._lo += right._lo;
            if (left._lo < right._lo)
                ++left._hi;
            return left;
        }

        public static Int128 operator -(Int128 left, Int128 right) => left + -right;

        public static Int128 operator %(Int128 dividend, Int128 divisor) => Int128.Remainder(dividend, divisor);

        public static Int128 operator /(Int128 dividend, Int128 divisor) => Int128.Divide(dividend, divisor);

        public static Int128 operator *(Int128 left, Int128 right) => Int128.Multiply(left, right);

        public static Int128 operator >>(Int128 value, int shift)
        {
            if (shift == 0)
                return value;
            ulong[] numArray = MathUtils.ShiftRightSigned(value.ToUIn64Array(), shift);
            value._hi = numArray[1];
            value._lo = numArray[0];
            return value;
        }

        public static Int128 operator <<(Int128 value, int shift)
        {
            if (shift == 0)
                return value;
            ulong[] numArray = MathUtils.ShiftLeft(value.ToUIn64Array(), shift);
            value._hi = numArray[1];
            value._lo = numArray[0];
            return value;
        }

        public static Int128 operator |(Int128 left, Int128 right)
        {
            if (left == (Int128)0)
                return right;
            if (right == (Int128)0)
                return left;
            Int128 int128 = left;
            int128._hi |= right._hi;
            int128._lo |= right._lo;
            return int128;
        }

        public static Int128 operator &(Int128 left, Int128 right)
        {
            if (left == (Int128)0 || right == (Int128)0)
                return Int128.Zero;
            Int128 int128 = left;
            int128._hi &= right._hi;
            int128._lo &= right._lo;
            return int128;
        }

        public static Int128 operator ~(Int128 value) => new Int128(~value._hi, ~value._lo);

        public static Int128 operator ++(Int128 value) => value + (Int128)1;

        public static Int128 operator --(Int128 value) => value - (Int128)1;
    }
}
