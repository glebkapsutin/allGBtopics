using System;
using System.Linq;
using System.Reflection;
using System.Text;

public static class ObjectSerializer
{
    public static string ObjectToString(object o)
    {
        Type type = o.GetType();
        StringBuilder res = new StringBuilder();
        res.Append(type.Assembly.GetName().Name + ":");  // Имя сборки
        res.Append(type.Name + "|");  // Имя класса

        // Обрабатываем свойства
        foreach (var prop in type.GetProperties())
        {
            var customNameAttr = prop.GetCustomAttribute<CustomNameAttribute>();
            string name = customNameAttr?.Name ?? prop.Name;  // Имя из атрибута или имя свойства
            var value = prop.GetValue(o);
            res.Append(name + "=");
            if (prop.PropertyType == typeof(char[]))
            {
                res.Append(new string(value as char[]) + "|");
            }
            else
            {
                res.Append(value?.ToString() + "|");
            }
        }

        // Обрабатываем поля
        foreach (var field in type.GetFields())
        {
            var customNameAttr = field.GetCustomAttribute<CustomNameAttribute>();
            string name = customNameAttr?.Name ?? field.Name;  // Имя из атрибута или имя поля
            var value = field.GetValue(o);
            res.Append(name + "=");
            if (field.FieldType == typeof(char[]))
            {
                res.Append(new string(value as char[]) + "|");
            }
            else
            {
                res.Append(value?.ToString() + "|");
            }
        }

        return res.ToString();
    }
}
