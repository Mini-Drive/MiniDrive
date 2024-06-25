using Microsoft.EntityFrameworkCore;
namespace MiniDrive.Infrastructure.Contexts
{
    public class MiniDriveContext : DbContext
    {
        public MiniDriveContext(DbContextOptions<MiniDriveContext> options) : base(options){

        }
    }
}