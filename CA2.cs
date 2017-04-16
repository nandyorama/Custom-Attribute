using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CustomAttribute1
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Method , AllowMultiple = true)] 
    public class CheckAttribute : Attribute
    {
        //Below Constructor needed for Line [Check(Length = 10)]
        public CheckAttribute()
        {
        }

        public CheckAttribute(String Description)
        {
            this.description = Description;
        }
        protected String description;
        public String Description
        {
            get
            {
                return this.description;

            }
        }
        public int Length { get; set; }
    }

    [Check("This is a do-nothing Class.")]
    public class Sample
    {
        [Check("This is a do-nothing Method.")]
        public void SampleMethod()
        {
        }
        
        private int sample;
        //AllowMultiple = true For Below 
        [Check("This is any Integer.")]
        [Check(Length = 10)]// public CheckAttribute(){}
        public int SampleInt{
            get { return sample; } 
            set { sample = value; }
        }
    }

    class QueryApp
    {
        public static void Main()
        {

            Type type = typeof(Sample);
            CheckAttribute HelpAttr;

            //Querying Class Attributes
            foreach (Attribute attr in type.GetCustomAttributes(true))
            {
                HelpAttr = attr as CheckAttribute;
                if (null != HelpAttr)
                {
                    Console.WriteLine("Description of AnyClass:\n{0}",
                                      HelpAttr.Description);
                }
            }

            //Querying Class-Method Attributes  
            foreach (MethodInfo method in type.GetMethods())
            {
                foreach (Attribute attr in method.GetCustomAttributes(true))
                {
                    HelpAttr = attr as CheckAttribute;
                    if (null != HelpAttr)
                    {
                        Console.WriteLine("Description of {0}:\n{1}",
                                          method.Name,
                                          HelpAttr.Description);
                    }
                }
            }

            //Querying Class-Property (only public) Attributes
            foreach (PropertyInfo field in type.GetProperties())
            {
                foreach (Attribute attr in field.GetCustomAttributes(true))
                {
                    HelpAttr = attr as CheckAttribute;
                    if (null != HelpAttr)
                    {
                        Console.WriteLine("Description of {0}:\n{1}:\n{2}",
                                          field.Name, HelpAttr.Description, HelpAttr.Length);
                    }
                }
            }
            System.Console.ReadLine();
        }
    }
}
