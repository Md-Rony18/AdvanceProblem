using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JasonFormater
{
    public static class JsonFormate
    {
        public static string Convert<T>(T item)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetType(item.ToString());
            PropertyInfo[] propertyInfos = type.GetProperties(); 
            string temp = "";
            foreach (var items in propertyInfos) 
            {
                var proval="";
                if (items.PropertyType == typeof(string) | items.PropertyType == typeof(int) | items.PropertyType == typeof(double) |items.PropertyType==typeof(DateTime))
                {
                    proval += "\"";
                    proval += items.GetValue(item, null);
                    proval += "\"";
                    proval += ",";
                   
                }
                temp += "\"" + items.Name + "\"" + ":" + proval;
                temp += "\n";
                object val=items.GetValue(item, null);
                var elements = val as IList;
                if (elements != null)
                {
                    temp += "[";
                    temp += "\n";
                    foreach (var pi in elements)
                    {
                        
                        temp += "{";
                        temp += "\n";
                        temp += Convert(pi);
                        temp += "}";
                        temp += ",";
                        temp +="\n";
                        
                    }
                    temp += "]";
                    temp += ",";
                    temp += "\n";
                }
                if (items.PropertyType.Assembly==type.Assembly)
                {
                    temp += "{";
                    temp += "\n";
                    temp += Convert(items.GetValue(item,null));
                    temp +="}";
                    temp += ",";
                    temp += "\n";
                }
            }
            return temp;
        }

    }
}
