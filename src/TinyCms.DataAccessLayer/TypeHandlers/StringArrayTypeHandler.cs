using System.Data;
using Dapper;

namespace TinyCms.DataAccessLayer.TypeHandlers;

internal class StringArrayTypeHandler(string separator = StringArrayTypeHandler.DefaultSeparator) : SqlMapper.TypeHandler<string[]>
{
    private const string DefaultSeparator = ";";

    public override string[]? Parse(object value)
    {
        var values = value.ToString()?.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        return values;
    }

    public override void SetValue(IDbDataParameter parameter, string[]? value)
    {
        parameter.Value = string.Join(separator, value ?? []);
        parameter.DbType = DbType.String;
    }
}
