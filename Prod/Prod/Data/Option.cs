﻿#region License
// // Copyright 2012 deweyvm, see also AUTHORS file.
// // Licenced under GPL v3
// // see LICENCE file for more information or visit http://www.gnu.org/licenses/gpl-3.0.txt
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prod.Data
{
    /// <summary>
    /// An option type to represent a result which may or may not contain 
    /// a value.
    /// </summary>
    public sealed class Option<T>
    {
        public readonly bool HasValue;
        public readonly T Value;
        public static readonly Option<T> None = new Option<T>();

        public Option(T value)
        {
            this.Value = value;
            this.HasValue = true;
        }

        private Option()
        {
            this.HasValue = false;
        }

        public Option<R> Map<R>(Func<T, R> converter)
        {
            if (this.HasValue)
            {
                return new Option<R>(converter(this.Value));
            }
            else
            {
                return Option<R>.None;
            }
        }

        public override string ToString()
        {
            string str;
            if (Value == null)
            {
                str = "null";
            }
            else
            {
                str = Value.ToString().Replace("\0", "");
            }
            return string.Format("Option<{0}>({1})", typeof (T).Name, str);
        }


    }
}
