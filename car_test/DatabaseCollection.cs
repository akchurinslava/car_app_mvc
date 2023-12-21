using System;
namespace car_test
{
    [CollectionDefinition("DatabaseCollection")]
    public class DatabaseCollectionDefinition : ICollectionFixture<TestDatabaseFixture>
    {
        
    }

    public class DatabaseCollection : IDisposable
    {
        private readonly TestDatabaseFixture _fixture;

        public DatabaseCollection(TestDatabaseFixture fixture)
        {
            _fixture = fixture;
            
        }

        public void Dispose()
        {
            
        }
    }
}

