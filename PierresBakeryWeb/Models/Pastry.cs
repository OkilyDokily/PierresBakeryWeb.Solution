namespace PierresBakeryWeb.Models
{
    //any subobject must either inherit from a category abstact class
    //or provide it's own Category
    //Category abstract classes provide default implementation that
    //a subclass can override.
    public class Pastry : BakeryItem
    { 
        public Pastry()
        {
            Category = "Pastry";
            DealPrice = 5;
            Multiplier = 3;
            SinglePrice = 2; 
        }
    }
}