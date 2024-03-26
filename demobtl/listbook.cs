using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dexuatsach
{
    public class listbook
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public listbook(string name, string image)
        {
            Name = name;
            Image = image;
        }
    }
}
