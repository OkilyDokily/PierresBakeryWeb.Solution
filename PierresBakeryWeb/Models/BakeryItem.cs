namespace PierresBakeryWeb.Models
{
    // All values ultimately reside in the bakeryitem class
    // this makes polymorphism much easier since it ensures all subobjects
    // have access to the same fields, properties and methods
    public abstract class BakeryItem
    {
        public string Category{get; set;}
        public int SinglePrice{get; set;}
        public int Multiplier{get; set;}
        public int DealPrice{get; set;}
        public int Deal(int amount)
        {
            int deal = amount / Multiplier;
            return (deal * DealPrice) + ((amount % Multiplier) * SinglePrice); 
        }
    }
}