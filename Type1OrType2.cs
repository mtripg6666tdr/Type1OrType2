using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSystem
{ 
    public enum DataType
    {
        /// <summary>
        /// 中身のオブジェクトはジェネリックの引数の一番目に指定したオブジェクトです
        /// 例えば、＜string,int＞の時、中身の型はstringです
        /// </summary>
        Type1,
        /// <summary>
        /// 中身のオブジェクトはジェネリックの引数の二番目に指定したオブジェクトです
        /// 例えば、＜string,int＞の時、中身の型はintです
        /// </summary>
        Type2
    }

    public struct NumType1OrNumType2<T1, T2> : IType1OrType2 where T1 : struct where T2 : struct
    {
        private T1? data1;
        private T2? data2;
        public DataType Type { get; private set; }
        [Obsolete("This property is not safety due to boxing.")]
        public object Data
        {
            get => this.Type == DataType.Type1 ? (object)this.data1 : this.data2;
        }

        private NumType1OrNumType2(T1 data)
        {
            this.Type = DataType.Type1;
            this.data1 = data;
            this.data2 = null;
        }

        private NumType1OrNumType2(T2 data)
        {
            this.Type = DataType.Type2;
            this.data1 = null;
            this.data2 = data;
        }

        public static explicit operator T1(NumType1OrNumType2<T1,T2> num)
        {
            if(num.Type == DataType.Type1)
            {
                return (T1)num.data1;
            }
            else
            {
                throw new InvalidCastException("指定した型の実態は指定した型ではありません");
            }
        }

        public static explicit operator T2(NumType1OrNumType2<T1,T2> num)
        {
            if(num.Type == DataType.Type2)
            {
                return (T2)num.data2;
            }
            else
            {
                throw new InvalidCastException("指定した型の実態は指定した型ではありません");
            }
        }

        public static implicit operator NumType1OrNumType2<T1,T2>(T1 num)
        {
            return new NumType1OrNumType2<T1, T2>(num);
        }

        public static implicit operator NumType1OrNumType2<T1,T2>(T2 num)
        {
            return new NumType1OrNumType2<T1, T2>(num);
        }
    }

    public class NumType1OrRefType2<T1,T2> : IType1OrType2 where T1 : struct where T2 : class
    {
        private T1? data1;
        private T2 data2;
        public DataType Type { get; private set; }
        [Obsolete("This property is not safety due to boxing.")]
        public object Data
        {
            get => this.Type == DataType.Type1 ? (object)this.data1 : this.data2;
        }

        private NumType1OrRefType2(T1 data)
        {
            this.Type = DataType.Type1;
            this.data1 = data;
            this.data2 = null;
        }

        private NumType1OrRefType2(T2 data)
        {
            this.Type = DataType.Type2;
            this.data1 = null;
            this.data2 = data;
        }

        public static explicit operator T1(NumType1OrRefType2<T1, T2> num)
        {
            if (num.Type == DataType.Type1)
            {
                return (T1)num.data1;
            }
            else
            {
                throw new InvalidCastException("指定した型の実態は指定した型ではありません");
            }
        }

        public static explicit operator T2(NumType1OrRefType2<T1, T2> num)
        {
            if (num.Type == DataType.Type2)
            {
                return num.data2;
            }
            else
            {
                throw new InvalidCastException("指定した型の実態は指定した型ではありません");
            }
        }

        public static implicit operator NumType1OrRefType2<T1,T2>(T1 num)
        {
            return new NumType1OrRefType2<T1, T2>(num);
        }
        public static implicit operator NumType1OrRefType2<T1,T2>(T2 val)
        {
            return new NumType1OrRefType2<T1, T2>(val);
        }
    }

    public class RefType1OrRefType2<T1, T2> : IType1OrType2 where T1 : class where T2 : class
    {
        private T1 data1;
        private T2 data2;
        public DataType Type { get; private set; }
        public object Data
        {
            get => this.Type == DataType.Type1 ? (object)this.data1 : this.data2;
        }

        private RefType1OrRefType2(T1 data)
        {
            this.Type = DataType.Type1;
            this.data1 = data;
            this.data2 = null;
        }

        private RefType1OrRefType2(T2 data)
        {
            this.Type = DataType.Type2;
            this.data1 = null;
            this.data2 = data;
        }

        public static explicit operator T1(RefType1OrRefType2<T1, T2> num)
        {
            if (num.Type == DataType.Type1)
            {
                return (T1)num.data1;
            }
            else
            {
                throw new InvalidCastException("指定した型の実態は指定した型ではありません");
            }
        }

        public static explicit operator T2(RefType1OrRefType2<T1, T2> num)
        {
            if (num.Type == DataType.Type2)
            {
                return num.data2;
            }
            else
            {
                throw new InvalidCastException("指定した型の実態は指定した型ではありません");
            }
        }

        public static implicit operator RefType1OrRefType2<T1,T2>(T1 val)
        {
            return new RefType1OrRefType2<T1, T2>(val);
        }

        public static implicit operator RefType1OrRefType2<T1,T2>(T2 val)
        {
            return new RefType1OrRefType2<T1, T2>(val);
        }
    }
}
