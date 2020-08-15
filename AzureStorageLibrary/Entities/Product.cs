using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Cosmos.Table;

namespace AzureStorageLibrary.Entities
{

    //
    public class Product : TableEntity
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Color { get; set; }



    }
}
