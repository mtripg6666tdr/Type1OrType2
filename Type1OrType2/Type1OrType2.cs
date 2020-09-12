using System;

namespace mtripg6666tdr.Type1OrType2
{
    /// <summary>
    /// Type1OrType2クラスの基底インターフェースです。
    /// Type1OrType2クラスのすべてのクラスはこのインターフェースとして扱うことができます。
    /// </summary>
    /// <typeparam name="T1">中身のオブジェクトはジェネリックの引数の一番目に指定したオブジェクトです。
    /// 例えば、&lt;string,int&gt;の時、中身の型はstringです</typeparam>
    /// <typeparam name="T2">中身のオブジェクトはジェネリックの引数の二番目に指定したオブジェクトです。
    /// 例えば、&lt;string,int&gt;の時、中身の型はintです</typeparam>
    public interface IType1OrType2<T1, T2>
    {
        /// <summary>
        /// 実際に格納されているデータ。
        /// </summary>
        object Data { get; }
        /// <summary>
        /// 実際に格納されているデータの種類。
        /// </summary>
        DataType Type { get; }
    }

    /// <summary>
    /// Type1OrType2クラス/構造体で実際に格納されているデータの種類を表します。
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// 中身のオブジェクトはジェネリックの引数の一番目に指定したオブジェクトです
        /// 例えば、&lt;string,int&gt;の時、中身の型はstringです
        /// </summary>
        Type1,
        /// <summary>
        /// 中身のオブジェクトはジェネリックの引数の二番目に指定したオブジェクトです
        /// 例えば、&lt;string,int&gt;の時、中身の型はintです
        /// </summary>
        Type2
    }

    /// <summary>
    /// 特定の二種類の値型のうちどちらかのデータを格納する構造体です。
    /// </summary>
    /// <typeparam name="T1">特定の二種類の値型のうち一つ目の値型</typeparam>
    /// <typeparam name="T2">特定の二種類の値型のうち二つ目の値型</typeparam>
    public struct NumType1OrNumType2<T1, T2> : IType1OrType2<T1,T2> where T1 : struct where T2 : struct
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

        /// <summary>
        /// 明示的にキャストした際にそのデータ型として格納されているデータを返します
        /// </summary>
        /// <param name="num">キャスト元のデータ</param>
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

        /// <summary>
        /// 明示的にキャストした際にそのデータ型として格納されているデータを返します
        /// </summary>
        /// <param name="num">キャスト元のデータ</param>
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

        /// <summary>
        /// 暗黙的にキャストする機能を提供するオペレーター。
        /// </summary>
        /// <param name="num"></param>
        public static implicit operator NumType1OrNumType2<T1,T2>(T1 num)
        {
            return new NumType1OrNumType2<T1, T2>(num);
        }

        /// <summary>
        /// 暗黙的にキャストする機能を提供するオペレーター。
        /// </summary>
        /// <param name="num"></param>
        public static implicit operator NumType1OrNumType2<T1,T2>(T2 num)
        {
            return new NumType1OrNumType2<T1, T2>(num);
        }
    }

    /// <summary>
    /// 特定の値型と参照型のうちどちらかのデータを格納する構造体です。
    /// </summary>
    /// <typeparam name="T1">特定の値型と参照型のうち値型</typeparam>
    /// <typeparam name="T2">特定の値型と参照型のうち参照型</typeparam>
    public class NumType1OrRefType2<T1,T2> : IType1OrType2<T1, T2> where T1 : struct where T2 : class
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

        /// <summary>
        /// 明示的にキャストした際にそのデータ型として格納されているデータを返します
        /// </summary>
        /// <param name="num">キャスト元のデータ</param>
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

        /// <summary>
        /// 明示的にキャストした際にそのデータ型として格納されているデータを返します
        /// </summary>
        /// <param name="num">キャスト元のデータ</param>
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

        /// <summary>
        /// 暗黙的にキャストする機能を提供するオペレーター。
        /// </summary>
        /// <param name="num"></param>
        public static implicit operator NumType1OrRefType2<T1,T2>(T1 num)
        {
            return new NumType1OrRefType2<T1, T2>(num);
        }

        /// <summary>
        /// 暗黙的にキャストする機能を提供するオペレーター。
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator NumType1OrRefType2<T1,T2>(T2 val)
        {
            return new NumType1OrRefType2<T1, T2>(val);
        }
    }

    /// <summary>
    /// 特定の二種類の参照型のうちどちらかのデータを格納する構造体です。
    /// </summary>
    /// <typeparam name="T1">特定の二種類の参照型のうち一つ目の参照型</typeparam>
    /// <typeparam name="T2">特定の二種類の参照型のうち二つ目の参照型</typeparam>
    public class RefType1OrRefType2<T1, T2> : IType1OrType2<T1, T2> where T1 : class where T2 : class
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

        /// <summary>
        /// 明示的にキャストした際にそのデータ型として格納されているデータを返します
        /// </summary>
        /// <param name="num">キャスト元のデータ</param>
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

        /// <summary>
        /// 明示的にキャストした際にそのデータ型として格納されているデータを返します
        /// </summary>
        /// <param name="num">キャスト元のデータ</param>
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

        /// <summary>
        /// 暗黙的にキャストする機能を提供するオペレーター。
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator RefType1OrRefType2<T1,T2>(T1 val)
        {
            return new RefType1OrRefType2<T1, T2>(val);
        }

        /// <summary>
        /// 暗黙的にキャストする機能を提供するオペレーター。
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator RefType1OrRefType2<T1,T2>(T2 val)
        {
            return new RefType1OrRefType2<T1, T2>(val);
        }
    }
}
