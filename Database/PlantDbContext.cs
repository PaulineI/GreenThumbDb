using GreenThumb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GreenThumb.Database
{
    public class PlantDbContext : DbContext
    {

        public PlantDbContext()
        {


        }

        public DbSet<PlantModel> Plants { get; set; }

        public DbSet<InstructionModel> Instruction { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PlantDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Sätta delete behavior ??

            //modelBuilder.Entity<PlantModel>()
            //    .HasMany(p => p.Instructions)
            //    .WithOne(p => p.Plant);

            //modelBuilder.Entity<InstructionModel>()

            modelBuilder.Entity<PlantModel>()
                .HasData(new PlantModel()
                {
                    PlantId = 1,
                    Name = "Rose"

                }, new PlantModel()
                {
                    PlantId = 2,
                    Name = "Tulip"

                }, new PlantModel()
                {
                    PlantId = 3,
                    Name = "Magnolia"

                }, new PlantModel()
                {
                    PlantId = 4,
                    Name = "Daisy"

                }, new PlantModel()
                {
                    PlantId = 5,
                    Name = "Orchid"
                });

            modelBuilder.Entity<InstructionModel>()
                .HasData(new InstructionModel()
                {
                    Id = 1,
                    Instruction = "Sunlight",
                    PlantId = 1,
                }, new InstructionModel()
                {
                    Id = 2,
                    Instruction = "Cut the edges",
                    PlantId = 2

                }, new InstructionModel()
                {
                    Id = 3,
                    Instruction = "No sun",
                    PlantId = 3
                }, new InstructionModel()
                {
                    Id = 4,
                    Instruction = "Don't keep in direct sunlight",
                    PlantId = 4
                }, new InstructionModel()
                {
                    Id = 5,
                    Instruction = "Water once every week",
                    PlantId = 4

                }, new InstructionModel()
                {
                    Id = 6,
                    Instruction = "Warm water",
                    PlantId = 5
                });

        }



    }
}
