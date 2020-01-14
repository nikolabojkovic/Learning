// Type: System.Xml.XmlWriter
// Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\Profile\Client\System.Xml.dll

using System;
using System.IO;
using System.Runtime;
using System.Text;
using System.Xml.XPath;

namespace System.Xml
{
	public abstract class XmlWriter : IDisposable
	{
		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		protected XmlWriter();

		public virtual XmlWriterSettings Settings { get; }
		public abstract WriteState WriteState { get; }
		public virtual XmlSpace XmlSpace { get; }

		public virtual string XmlLang { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		get; }

		#region IDisposable Members

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		void IDisposable.Dispose();

		#endregion

		public abstract void WriteStartDocument();
		public abstract void WriteStartDocument(bool standalone);
		public abstract void WriteEndDocument();
		public abstract void WriteDocType(string name, string pubid, string sysid, string subset);

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public void WriteStartElement(string localName, string ns);

		public abstract void WriteStartElement(string prefix, string localName, string ns);

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public void WriteStartElement(string localName);

		public abstract void WriteEndElement();
		public abstract void WriteFullEndElement();

		[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
		public void WriteAttributeString(string localName, string ns, string value);

		public void WriteAttributeString(string localName, string value);
		public void WriteAttributeString(string prefix, string localName, string ns, string value);

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public void WriteStartAttribute(string localName, string ns);

		public abstract void WriteStartAttribute(string prefix, string localName, string ns);

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public void WriteStartAttribute(string localName);

		public abstract void WriteEndAttribute();
		public abstract void WriteCData(string text);
		public abstract void WriteComment(string text);
		public abstract void WriteProcessingInstruction(string name, string text);
		public abstract void WriteEntityRef(string name);
		public abstract void WriteCharEntity(char ch);
		public abstract void WriteWhitespace(string ws);
		public abstract void WriteString(string text);
		public abstract void WriteSurrogateCharEntity(char lowChar, char highChar);
		public abstract void WriteChars(char[] buffer, int index, int count);
		public abstract void WriteRaw(char[] buffer, int index, int count);
		public abstract void WriteRaw(string data);
		public abstract void WriteBase64(byte[] buffer, int index, int count);
		public virtual void WriteBinHex(byte[] buffer, int index, int count);
		public abstract void Close();
		public abstract void Flush();
		public abstract string LookupPrefix(string ns);
		public virtual void WriteNmToken(string name);
		public virtual void WriteName(string name);
		public virtual void WriteQualifiedName(string localName, string ns);
		public virtual void WriteValue(object value);
		public virtual void WriteValue(string value);
		public virtual void WriteValue(bool value);
		public virtual void WriteValue(DateTime value);
		public virtual void WriteValue(double value);
		public virtual void WriteValue(float value);
		public virtual void WriteValue(decimal value);
		public virtual void WriteValue(int value);
		public virtual void WriteValue(long value);
		public virtual void WriteAttributes(XmlReader reader, bool defattr);
		public virtual void WriteNode(XmlReader reader, bool defattr);
		public virtual void WriteNode(XPathNavigator navigator, bool defattr);

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public void WriteElementString(string localName, string value);

		public void WriteElementString(string localName, string ns, string value);
		public void WriteElementString(string prefix, string localName, string ns, string value);

		protected virtual void Dispose(bool disposing);

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static XmlWriter Create(string outputFileName);

		public static XmlWriter Create(string outputFileName, XmlWriterSettings settings);

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static XmlWriter Create(Stream output);

		public static XmlWriter Create(Stream output, XmlWriterSettings settings);

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static XmlWriter Create(TextWriter output);

		public static XmlWriter Create(TextWriter output, XmlWriterSettings settings);

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static XmlWriter Create(StringBuilder output);

		public static XmlWriter Create(StringBuilder output, XmlWriterSettings settings);

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static XmlWriter Create(XmlWriter output);

		public static XmlWriter Create(XmlWriter output, XmlWriterSettings settings);
	}
}
