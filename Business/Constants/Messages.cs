using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public const string ProductsListed = "Products listed successfully";
        public const string ProductListed = "Product listed successfully";
        public const string MaintenanceTime = "System is in maintenance now...";        
        public const string ProductNameInvalid = "Invalid product name";
        public const string ProductAdded = "Product Added Successfully";
        public static string ProductCountOfCategoryExceeded = "Maximum number of a category exceeded";

        public static string ProductNameAlreadyExist = "Product with this name is already exists.";
        internal static string CategoryCountExceeded = "Maximum category count exceeded";
    }
}
