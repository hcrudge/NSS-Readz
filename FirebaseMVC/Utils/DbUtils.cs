using System;
using Microsoft.Data.SqlClient;

namespace Readz.Utils
{
    
    public static class DbUtils
    {
        //Helper method to add the SQL returned string to the object property. 
        // Turns a null database value to C# null.
        public static string GetNullableString(SqlDataReader reader, string column)
        {
            var ordinal = reader.GetOrdinal(column);
            if (reader.IsDBNull(ordinal))
            {
                return null;
            }
            return reader.GetString(ordinal);
        }

        //Helper method to add the SQL returned DateTime to the object property. 
        // Turns a null database value to C# null.
        public static DateTime? GetNullableDateTime(SqlDataReader reader, string column)
        {
            var ordinal = reader.GetOrdinal(column);
            if (reader.IsDBNull(ordinal))
            {
                return null;
            }
            return reader.GetDateTime(ordinal);
        }

        // Helper method which returns the value of the left-hand operand
        // if it isn't null; otherwise it evaluates the right-hand operand
        // and returns its result.
        public static object ValueOrDBNull(object value)
        {
            return value ?? DBNull.Value;
        }
    }
}

