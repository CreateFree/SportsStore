using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage ="请输入一个名称")]
        public string Name { get; set; }

        [Required(ErrorMessage ="请输入第一个地址线")]
        [Display(Name="Line1")]
        public string Line1 { get; set; }
        [Display(Name = "Line2")]
        public string Line2 { get; set; }
        [Display(Name = "Line3")]
        public string Line3 { get; set; }

        [Required(ErrorMessage ="请输入一个城市名称")]
        public string City { get; set; }

        [Required(ErrorMessage ="请输入一个站名称")]
        public string State { get; set; }
        public string Zip { get; set; }

        [Required(ErrorMessage ="请输入一个国家名称")]
        public string Country { get; set; }
        public string GifWrap { get; set; }
    }
}
