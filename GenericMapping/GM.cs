using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace GenericMapping
{
    public class GenericMapping
    {
        /// <summary>
        /// Convert to T1 class from T2 class. (Need equal property name and property type)
        /// </summary>
        /// <typeparam name="T1">Return item class</typeparam>
        /// <typeparam name="T2">Send item class</typeparam>
        /// <param name="item">Send item instance</param>
        /// <returns></returns>
        public static T1 Map<T1, T2>(T2 item)
        {
            T1 returnItem = (T1)Activator.CreateInstance<T1>();
            var returnType = returnItem.GetType();
            var returnProperties = returnType.GetProperties();

            var itemType = item.GetType();
            var itemProperties = itemType.GetProperties();

            returnProperties.All(returnAll =>
            {
                itemProperties.Where(w => w.Name == returnAll.Name)
                              .Single(s =>
                              {
                                  var p1value = s.GetValue(item, null);
                                  if (p1value != null)
                                      returnAll.SetValue(returnItem, p1value);

                                  return true;
                              });

                return true;
            });

            return returnItem;
        }


        /// <summary>
        /// Bir sınıftan diğer bir sınıfa çevirimi sağlar
        /// </summary>
        /// <typeparam name="T1">Return item class</typeparam>
        /// <typeparam name="T2">Send item class</typeparam>
        /// <param name="item1">Return item instance</param>
        /// /// <param name="item2">Send item instance</param>
        /// <returns></returns>
        public static T1 Map<T1, T2>(T1 item1, T2 item2)
        {
            T1 returnItem = (T1)Activator.CreateInstance<T1>();
            //var returnType = returnItem.GetType();
            var returnProperties = returnItem.GetType().GetProperties();

            //var item1Type = item1.GetType();
            var item1Properties = item1.GetType().GetProperties();

            //var item2Type = item2.GetType();
            var item2Properties = item2.GetType().GetProperties();

            returnProperties.All(returnAll =>
            {
                item2Properties.Where(w => w.Name == returnAll.Name)
                               .Single(s1 =>
                               {
                                   var p1value = s1.GetValue(item2, null);
                                   if (p1value != null)
                                       returnAll.SetValue(returnItem, p1value);
                                   else
                                   {
                                       item1Properties.Where(w => w.Name == returnAll.Name)
                                                      .Single(s2 =>
                                                      {
                                                          var p2value = s2.GetValue(item1, null);
                                                          returnAll.SetValue(returnItem, p2value);

                                                          return true;
                                                      });
                                   }

                                   return true;
                               });

                return true;
            });

            return returnItem;
        }

    }
}
