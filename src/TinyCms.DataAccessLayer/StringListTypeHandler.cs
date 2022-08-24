using System.Data;
using Dapper;

namespace TinyCms.DataAccessLayer;
public class StringListTypeHandler : SqlMapper.TypeHandler<List<string>>
{
    public override List<string> Parse(object value)
    {
        var values = value.ToString().Split(";", StringSplitOptions.RemoveEmptyEntries);
        return values.ToList();
    }

    public override void SetValue(IDbDataParameter parameter, List<string> value)
    {
        parameter.Value = string.Join(";", value);
    }
}
