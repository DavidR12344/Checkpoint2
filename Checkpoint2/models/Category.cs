using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint2.models
{

    public class Category
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="categoryName"></param>
        public Category(string categoryName)
        {
            CategoryName = categoryName;
        }
         
        /// <summary>
        /// Get and set method for CategoryName
        /// </summary>
        public string CategoryName { get; set; }
    }
}
