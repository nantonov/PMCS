namespace PMCS.DAL.Tests
{
    public class DALIntegrationTestsBase : IDisposable
    {
        protected AppContext _context = new AppContext(new DbContextOptionsBuilder<AppContext>().
            UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
