using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;

namespace TestTask.Models
{
    /// <summary>
    /// Сущность ответственная за записывание измененных полей формы в файл
    /// </summary>
    public class XmlWriter
    {
        /// <summary>
        /// Метод, осуществляющий записывание данных формы в файл
        /// </summary>
        /// <param name="data">Данные из формы</param>
        public void WriteToXml(IFormCollection data)
        {
            var root = XElement.Load("strings.xml");
            foreach (var el in root.Elements())
            {
                if (el.Name.ToString() != "string-array")
                {
                    if (data.ContainsKey((string) el.Attribute("name")))
                    {
                        el.Value = data[(string) el.Attribute("name")][0];
                    }
                    else
                    {
                        throw new ArgumentException("Не найден ключ");
                    }
                }
                else
                {
                    if (data.ContainsKey((string) el.Attribute("name")))
                    {
                        int i = 0;
                        foreach (var item in el.Elements("item"))
                        {
                            item.Value = data[(string)el.Attribute("name")][i];
                            i++;
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Не найден ключ");
                    }
                }
            }
            root.Save("strings.xml");
        }
    }
}