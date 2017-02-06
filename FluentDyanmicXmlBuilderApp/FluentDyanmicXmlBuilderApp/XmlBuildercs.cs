using System;
using System.Dynamic;
using System.Xml;

namespace FluentDyanmicXmlBuilderApp
{
    /// <summary>
    ///     An Helper Class To Build Strongly Typed XML 
    /// </summary>
    public class XmlBuilder : DynamicObject
    {
        #region "Variable Declarations"

        private readonly Func<string, XmlElement> createElement;
        private readonly Func<string, XmlAttribute> createAttribute;
        private readonly XmlNode node;

        #endregion "Variable Declarations"

        #region "Constructors"

        public XmlBuilder()
        {
            node = new XmlDocument();
            createElement = s => ((XmlDocument)node).CreateElement(s);
            createAttribute = s => ((XmlDocument)node).CreateAttribute(s);
        }

        private XmlBuilder(
            XmlNode node,
            Func<string, XmlElement> createElement,
            Func<string, XmlAttribute> createAttribute)
        {
            this.node = node;
            this.createElement = createElement;
            this.createAttribute = createAttribute;
        }

        #endregion "Constructors"

        #region "Overridden Dynamic Type Methods"
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            XmlNode found = node[binder.Name];
            if (found == null)
            {
                found = createElement(binder.Name);
                node.AppendChild(found);
            }

            result = new XmlBuilder(found, createElement, createAttribute);
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            XmlNode found = node[binder.Name];
            if (found == null)
            {
                found = createElement(binder.Name);
                node.AppendChild(found);
            }

            found.InnerText = value.ToString();
            return true;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            if (indexes.Length != 1)
            {
                throw new InvalidOperationException("You may only specify a single index.");
            }

            XmlNode found = null;
            var s = indexes[0] as string;
            if (s != null)
            {
                var name = s;
                found = node?.Attributes?[name];
                if (found == null)
                {
                    found = createElement(name);
                    node?.AppendChild(found);
                }
            }
            else if (indexes[0] is int)
            {
                var index = (int)indexes[0];
                found = node?.Attributes?[index];
            }

            if (found != null)
            {
                result = new XmlBuilder(found, createElement, createAttribute);
                return true;
            }
            result = null;
            return false;
        }

        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            if (indexes.Length != 1)
            {
                throw new InvalidOperationException("You may only specify a single index.");
            }

            XmlAttribute found = null;
            var s = indexes[0] as string;
            if (s != null)
            {
                var name = s;
                found = node?.Attributes?[name];
                if (found == null)
                {
                    found = createAttribute(name);
                    node?.Attributes?.Append(found);
                }
            }
            else if (indexes[0] is int)
            {
                var index = (int)indexes[0];
                found = node?.Attributes?[index];
            }

            if (found == null)
                return false;
            found.InnerText = value.ToString();
            return true;
        }

        public override string ToString()
        {
            return node.InnerXml;
        }

        #endregion "Overridden Dynamic Type Methods"
        
    }
}
