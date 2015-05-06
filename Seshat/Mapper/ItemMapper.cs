using System;
using System.Reflection;
using MikeRobbins.Seshat.Interfaces;
using Sitecore.Data.Items;
using Sitecore.Web.UI.XamlSharp.Xaml.Extensions;

namespace MikeRobbins.Seshat.Mapper
{
    public class ItemMapper : IItemMapper
    {
        public T MapItem<T>(Item source) where T : class
        {
            T returnValue = (T)Activator.CreateInstance(typeof(T));

            foreach (Sitecore.Data.Fields.Field field in source.Fields)
            {
                var property = typeof(T).GetProperty(field.Name.Replace(" ", ""));

                if (property != null)
                {
                    property.SetValue(returnValue, field.Value);
                }
            }

            return returnValue;
        }

        public T Map<T, S>(S source) where T : class where S : class
        {
            T returnValue = (T)Activator.CreateInstance(typeof(T));

            var sourceProperties = typeof(S).GetProperties();

            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                var destinationProperty = typeof(T).GetProperty(sourceProperty.Name);

                if (destinationProperty != null)
                {
                    destinationProperty.SetValue(returnValue, sourceProperty.GetValue(source));
                }
            }

            return returnValue;
        }
    }
}