using System.Data.SqlClient;

namespace FootballersBase.Repositories
{
    public interface IQueryRepository
    {
        SqlConnection CreateConnection();
    }
}
