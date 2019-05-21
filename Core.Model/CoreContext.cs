using Microsoft.EntityFrameworkCore;

namespace Core.Model
{
    public class CoreContext : DbContext
    {
        //构造方法
        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        { }

        #region 数据区域
        public DbSet<Member> User { get; set; }
        #endregion

    }
}
