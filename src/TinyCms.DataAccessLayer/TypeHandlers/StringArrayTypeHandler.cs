using System.Data;
using Dapper;

namespace TinyCms.DataAccessLayer.TypeHandlers;

internal class StringArrayTypeHandler : SqlMapper.TypeHandler<string[]>
{
    private const string defaultSeparator = ";";

    private readonly string separator;

    public StringArrayTypeHandler(string separator = defaultSeparator)
    {
        this.separator = separator ?? defaultSeparator;
    }

    public override string[] Parse(object value)
    {
        var values = value.ToString().Split(separator, StringSplitOptions.RemoveEmptyEntries);
        return values;
    }

    public override void SetValue(IDbDataParameter parameter, string[] value)
    {
        parameter.Value = string.Join(separator, value);
    }
}
