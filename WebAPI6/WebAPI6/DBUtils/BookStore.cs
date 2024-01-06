using Microsoft.EntityFrameworkCore;

namespace WebAPISix.DBUtils
{
    public class BookStore : DbContext
    {
        public BookStore(DbContextOptions<BookStore> opt) : base(opt)
        {

        }

        //tạo vùng region cho DbSet
        #region DbSet 
        public DbSet<Book>? Books { get; set; } //Book có thể bị null nên thêm dấu ? vô 

        #endregion
    }
}
