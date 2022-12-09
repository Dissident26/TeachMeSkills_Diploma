using DataBaseSeeder;
using DataBase.Contexts;

var ctx = new DbContextMain();

var seeder = new DbSeeder(ctx);

await seeder.Seed(100);