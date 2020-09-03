namespace PierresBakeryWeb.Models
{
 //any subobject must either inherit from a category abstact class
 //or provide it's own Category
 //Category abstract classes provide default implementation that
 //a subclass can override.
    public abstract class Bread : BakeryItem 
    {
        public Bread() 
        {
            Category = "Bread";
            Multiplier = 2;
            DealPrice = 5;
            SinglePrice = 5;
        }
    }
}