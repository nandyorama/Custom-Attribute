//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace CustomAttribute1
//{
//    [AttributeUsage(AttributeTargets.Property)]
//    class HelpAttribute : Attribute
//    {
//        public int MaxLength { get; set; }
//    }

//    class Customer
//    {
//        private string _CustomerId;

//        [HelpAttribute(MaxLength = 10)]
//        public string CustomerId
//        {
//            get { return _CustomerId; }
//            set { _CustomerId = value; }
//        }
//    }

//    class QueryApp
//    {
//        public static void Main()
//        {
//            Customer obj = new Customer();
//            obj.CustomerId = "12345678901";

//            Type type = typeof(Customer);
//            HelpAttribute HelpAttr;

//            foreach (System.Reflection.PropertyInfo p in type.GetProperties())
//            {
//                // for every property loop through all attributes
//                foreach (Attribute attr in p.GetCustomAttributes(false))
//                {
//                    HelpAttr = attr as HelpAttribute;
//                    if (p.Name == "CustomerId")
//                    {
//                        // Do the length check and and raise exception accordingly
//                        if (obj.CustomerId.Length > HelpAttr.MaxLength)
//                        {
//                            throw new Exception(" Max length issues ");
//                        }
//                    }
//                }
//            }
//        }
//    }
//}
