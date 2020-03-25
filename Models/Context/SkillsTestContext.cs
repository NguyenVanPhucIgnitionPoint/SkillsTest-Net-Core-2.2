using Microsoft.EntityFrameworkCore;

namespace SkillsTest.Models.Context
{
    public class SkillsTestContext : DbContext
    {
        public SkillsTestContext()
        {
        }

        public SkillsTestContext(DbContextOptions<SkillsTestContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}
