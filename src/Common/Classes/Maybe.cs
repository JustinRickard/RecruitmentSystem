using System;

namespace Common.Classes
{
    public class Maybe<T>
    {
        private T value;

        private Maybe () {}

        public Maybe (T value) {
            this.value = value;
        }        

        public T Value { 
            get {
                if (value != null) {
                    return value;
                }
                throw new InvalidOperationException(Constants.Errors.MaybeValueIsNull);
            }
        }

        public bool HasValue {
            get {
                return value != null;
            }
        }

        public bool HasNoValue => !HasValue;

        public static Maybe<T> Fail => new Maybe<T> ();

        /*
        public static Maybe<T> Fail () {
            return new Maybe<T>();
        }
        */
    }
}