using FlashcardsAPI.EF.MSSQL.Model;
using Microsoft.EntityFrameworkCore;

namespace FlashcardsAPI.EF.MSSQL.DataAccessLayer;

public class FlashcardsDataContext : DbContext
{
    
    public FlashcardsDataContext(DbContextOptions options) : base(options)
    {
    }

    // protected override void OnConfiguring()
    // {
    //     
    // }
    
    public DbSet<Flashcards> FlashcardsDb { get; set; }
    public DbSet<Stacks> StacksDb { get; set; }

}