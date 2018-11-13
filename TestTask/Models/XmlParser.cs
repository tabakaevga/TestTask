using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace TestTask.Models
{
    /// <summary>
    /// Сущность ответственная за считывание данных из файла
    /// </summary>
    public class XmlParser
    {
        /// <summary>
        /// Словарь из пар атрибута name тега и значения в теге
        /// </summary>
        public Dictionary<string, string[]> TagNameValuePairs { get; private set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public XmlParser()
        {
            TagNameValuePairs = ParseXml();
        }

        /// <summary>
        /// Метод, ответственный за считывание данных из файла
        /// </summary>
        /// <returns>Словарь атрибутов name и значений тега</returns>
        private Dictionary<string, string[]> ParseXml()
        {
            var root = XElement.Load("strings.xml");
            var parseResult = new Dictionary<string, string[]>();
            foreach (var el in root.Elements())
            {
                if (el.Name.ToString() != "string-array")
                {
                    parseResult.Add((string)el.Attribute("name"), new[] { el.Value });
                }
                else
                {
                    parseResult.Add((string)el.Attribute("name"), el.Elements("item")
                        .Select(elementOfArray => elementOfArray.Value).ToArray());
                }
            }
            return parseResult;
        }
    }
}