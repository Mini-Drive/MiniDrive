using Microsoft.EntityFrameworkCore;
using MiniDrive.Models;
namespace MiniDrive.Infrastructure.Contexts
{
    public class MiniDriveContext : DbContext
    {
        public MiniDriveContext(DbContextOptions<MiniDriveContext> options) : base(options){

        }
        //public DbSet<User> Users { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Models.File> Files { get; set; }
    }
}