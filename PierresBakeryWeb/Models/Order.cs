using System.Collections.Generic;
using System;

namespace PierresBakeryWeb.Models
{
    public static class Order
    {
        public static Dictionary<string, BakeryItem> objectDictionary = new Dictionary<string,BakeryItem>(){{"Brioche", new Brioche()},{"Zwieback",new Zwieback()},{"Cronut",new Cronut()},{"Croissant",new Croissant()}}; 
      
        public static Dictionary<string,int> ordersAmount = new Dictionary<string,int>();

        //This method returns a nested dictionary that can be looped through by the ui
        //code. The outer dictionary contains the names of the categories and the inner dictionary
        // includes the names of items specific to a category which correspond to an int array that
        // includes cost of a single items and the number of items that corresponds to
        // a particular deal price.
        public static Dictionary<string,Dictionary<string,int[]>> CreateItemsMenu()
        {
            Dictionary<string,Dictionary<string,int[]>> itemsMenu = new Dictionary<string, Dictionary<string, int[]>>();
            foreach(KeyValuePair<string,BakeryItem> item in objectDictionary)
            {
                int singlePrice = objectDictionary[item.Key].SinglePrice;
                int dealPrice = objectDictionary[item.Key].DealPrice;
                int multiplier = objectDictionary[item.Key].Multiplier;
                string category = objectDictionary[item.Key].Category;
                int[] arr = {singlePrice,dealPrice,multiplier};
               
                if(!itemsMenu.ContainsKey(category))
                {
                    Dictionary<string,int[]> items = new Dictionary<string,int[]>();
                    itemsMenu.Add(category,items);
                }
                itemsMenu[category].Add(item.Key,arr);
            }
            return itemsMenu;
        } 

        public static void AddToOrder(string str, int num)
        {
            if (objectDictionary.ContainsKey(str))
            {
                if(ordersAmount.ContainsKey(str))
                {
                    ordersAmount[str] += num; 
                }
                else
                {
                    ordersAmount.Add(str, num);
                }
            }
            else
            {
                throw new ArgumentException("The item was not found.");
            }
        }
        
        //This method returns a nested dictionary that can be looped through by the ui
        //code. The outer dictionary contains the names of the categories and the inner dictionary
        // includes the names of items specific to a category which correspon to an int array that
        // includes how many items have been purchased and the value of those items.
        public static Dictionary<string, Dictionary<string,int[]>> GetTotalsForAllOrder()
        {
            Dictionary<string,Dictionary<string,int[]>> totals = new Dictionary<string,Dictionary<string,int[]>>();  
            
            foreach(KeyValuePair<string,BakeryItem> entry in objectDictionary)
            {
                string key = entry.Key;
                int amount = 0;
                int total = 0;
                int[] arr = new int[2];
                BakeryItem bakery = objectDictionary[key];
                if(ordersAmount.ContainsKey(key))
                {
                    amount = ordersAmount[key];
                    total = bakery.Deal(amount);
                    arr[0] = amount;
                    arr[1] = total;
                    
                    string category = objectDictionary[key].Category;
                    if(!totals.ContainsKey(category))
                    {
                        int[] catArr = new int[]{0,0};
                        Dictionary<string,int[]> ofCategory = new Dictionary<string, int[]>(){{category, catArr}};
                        
                        totals.Add(category,ofCategory);   
                    }
                    //The first dictionary item in the nested dictionary keeps track of the 
                    //total item number and purchase price values within a category.
                    totals[category][category][0] += amount;
                    totals[category][category][1] += total; 
                    totals[category].Add(key, arr);    
                }
            }
            return totals;
        }
    }
}