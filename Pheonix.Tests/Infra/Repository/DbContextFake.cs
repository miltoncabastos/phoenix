using Microsoft.EntityFrameworkCore;
using Pheonix.Infra.Context;

namespace Pheonix.Tests.Infra.Repository
{
    public static class DbContextFake
    {
        public static PheonixContext GetDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PheonixContext>();
            optionsBuilder.UseInMemoryDatabase("PheonixMemory");
            return new PheonixContext(optionsBuilder.Options);
        }
    }
}
