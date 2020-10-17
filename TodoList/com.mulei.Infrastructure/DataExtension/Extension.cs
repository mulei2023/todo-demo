using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Com.Mulei.Infrastructure.Encryption
{
    public static class Extension
    {
        public static List<T> ToList<T>(this DataTable dt)
        {
            var dataColumn = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();

            var properties = typeof(T).GetProperties();
            string columnName = string.Empty;

            return dt.AsEnumerable().Select(row =>
            {
                var t = Activator.CreateInstance<T>();
                foreach (var p in properties)
                {
                    columnName = p.Name;
                    if (dataColumn.Contains(columnName))
                    {
                        if (!p.CanWrite)
                            continue;

                        object value = row[columnName];
                        Type type = p.PropertyType;

                        if (value != DBNull.Value)
                        {
                            p.SetValue(t, Convert.ChangeType(value, type), null);
                        }
                    }
                }
                return t;
            }).ToList();
        }

    }
}
