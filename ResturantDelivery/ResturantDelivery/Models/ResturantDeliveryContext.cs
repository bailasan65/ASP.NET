using Microsoft.EntityFrameworkCore;
using System;

namespace ResturantDelivery.Models
{


    public class ResturentDeliveryContext : DbContext
    {
        public ResturentDeliveryContext(DbContextOptions<ResturentDeliveryContext> options) : base(options) { }

        public DbSet<Customer> customerss { get; set; }
        public DbSet<orders> orderss{ get; set; }
        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    customerid = 1,
                    name = " ahmed",
                    phone = 0598741222,
                    address = "tubas",
                    password = "1234",
                    status = "admin"
                },

                 new Customer { customerid = 2,
                     name = " ali",
                     phone = 0568712482,
                     address = "tubas",
                     password = "2345",
                 status = "user"
                 },
                  new Customer { customerid = 3, name = " faries", phone = 0568741233, address = "jenin",
                      password = "4567",
					  status = "user"
				  },
                   new Customer { customerid = 4, name = "rahma", phone = 0598741552, address = "jenin", password = "8523", status = "user" },
                   new Customer { customerid = 5, name = "rawan", phone = 0598741882, address = "tubas", password = "9632", status = "user" }); ;
    

            modelBuilder.Entity<orders>().HasData(
                new orders {  id=1, Menuid = 1 ,name = "Burger", description = "withchicken ,botato,cola",quantity=1, customerid =1 },
                new orders { id =2, Menuid = 2, name = "pizza", description = "with olive,corn,mashroom",quantity=2, customerid =2 },
                new orders { id = 3, Menuid = 3,name = "shawrma", description = "with botato,cola",quantity=3, customerid =3},
                new orders { id = 4, Menuid = 4,name = "cupcakes", description = "five cupcakes with chocolate",quantity=2, customerid = 1 },
                new orders { id = 5, Menuid = 5, name = "Cake", description = " chocolate",quantity=1,customerid =4 },
                new orders { id = 6, Menuid = 6,name = "coffee", description = "with sugar or not ",quantity=2, customerid =1 },
                new orders { id = 7, Menuid = 7,name = "Tea", description = "green tea", quantity = 1,customerid =3 },
                new orders { id = 8, Menuid = 8,name = "iced coffee", description = "small cup",quantity=2, customerid =2 }
            
                );

            modelBuilder.Entity<Menu>().HasData(
                new Menu {Menuid  = 1, name = "Burger", price = 30, description = "withchicken or withmeat" },
                new Menu { Menuid = 2, name = "pizza", price = 40, description = "with olive,corn,mashroom,chick" },
                new Menu { Menuid = 3, name = "shawrma", price = 20, description = "bread+meat or chicken +salad" },
                new Menu { Menuid = 4, name = "cupcakes", price = 30, description = " cupcakes with chocolate" },
                new Menu { Menuid = 5, name = "Cake", price = 70, description = " chocolate, venila, lotes" },
                new Menu { Menuid = 6, name = "coffee", price = 3, description = "with sugar or not " },
                new Menu { Menuid = 7, name = "Tea", price = 2, description = "green tea" },
                new Menu { Menuid = 8, name = "iced coffee", price = 10, description = "small cup or medium ,large" },
                 new Menu { Menuid = 9, name = "Fettuccine", price = 35, description = "macaroni+chicken+cooking cream" },

                 new Menu { Menuid = 10, name = " Kibbeh", price = 15, description = "meat with bulgur or with chicken" },
                  new Menu { Menuid = 11, name = "lemon_Mint", price = 15, description = "a mixture of limon +mint" }

                );


        }
    }
}





