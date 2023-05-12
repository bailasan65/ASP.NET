

namespace ResturantDelivery.Models
{
    public class orders
    {
       
        public int id { get; set; }
      
       public int Menuid { get; set; } 
         public Menu Menu { get; set; } 
        public  string name { get; set; }
        public  string description { get; set; } 
           
        public float quantity { get; set; }   
        public int customerid { get; set; }
        public Customer Customer { get; set; }


    }
}
