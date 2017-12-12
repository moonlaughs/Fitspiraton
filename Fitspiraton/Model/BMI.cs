using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitspiraton.Model
{
    public class BMI
    {
        //auto properties
        public string Description { get; set; } = "Body mass index is a measure of body fat \nand is commonly used within the health industry \nto determine whether your weight is healthy.\nBMI applies to both adult men and women \nand is the calculation of body weight in relation to height.";
        public string Legend { get; set; } = "BMI Categories: " +
                                             "\nUnderweight = <18.5" +
                                             "\nNormal weight = 18.5–24.9" +
                                             "\nOverweight = 25–29.9" +
                                             "\nObesity = BMI of 30 or greater";
        
    }
}
