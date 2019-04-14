using System;

namespace ConvertToNullable.Util
{
    public static class Helper
    {
        /// <summary>
        /// Converts an object of unknown struct type to a nullable
        /// version of a different struct type. Only works if the given
        /// value is of a struct type (e.g. "int", "long", "int?").
        /// Mostly intended for converting from one non-nullable numeric
        /// type to a different *nullable* numeric type, e.g. "int -> long?"
        /// or "double -> decimal?"
        /// </summary>
        /// <typeparam name="T">The type which we want a nullable version of.
        /// Take note--if an "int?" is desired, the type parameter should
        /// actually be "int" without the question mark.</typeparam>
        /// <param name="value">The value to be converted to a nullable type</param>
        /// <returns></returns>
        public static T? ConvertToNullable<T>(object value) where T : struct
        {
            T? converted;

            //hate using a try/catch to implement this functionality, but
            //I couldn't figure out a way to do it using if-else. 
            try
            {
                converted = (T?)value;
            }
            catch (InvalidCastException ex)
            {
                converted = (T?)Convert.ChangeType(value, typeof(T));
            }

            return converted;
        }
    }
}
