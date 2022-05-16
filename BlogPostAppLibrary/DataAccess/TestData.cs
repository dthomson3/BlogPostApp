using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostAppLibrary.DataAccess;
public class TestData
{
    private readonly ISqlDataAccess _db;

    public Task<List<TestDataModel>> GetTestDataAsync()
    {
        string sql = "select * from TestData";

        return _db.LoadDataAsync<TestDataModel, dynamic>(sql, new { });
    }

    public Task InsertTestDataAsync(TestDataModel data)
    {
        string sql = @"insert into TestData (Name)
                        values (@Name);";

        return _db.SaveDataAsync(sql, data);
    }
}
