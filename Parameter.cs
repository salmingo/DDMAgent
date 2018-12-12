///////////////////////////////////////////////////////////////////////////////
/******************************************************************************
 * ManageConfig: 使用C#管理XML配置文件
 * 实现对自定义XML配置文件的读取、写入、更新操作
 * 访问接口:
 * 1) public string GetParamValue(string sectionName, string keyName, string defaultValue)
 * 2) public bool SetParamValue(string sectionName, string keyName, string value)
 * 
 * 如果sectionName不存在, 则创建section
 * 如果keyName不存在, 则创建key
 * 如果存在, 则对其读写、更新
 * 
 * @author :  卢晓猛
 * @date   :  2011年12月28日
 * @version:  0.1
 *****************************************************************************/
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Windows.Forms;

namespace XMLConfig
{
	class Parameter
	{
		// XML文件全路径名称
		private string m_fullPath = null;
		// XML文档
		private XmlDocument m_docXML = null;
		// XML文档修改标记
		private bool m_bModified = false;

		/*!
		 * \fn ManageConfig(string fullPath)
		 * \brief 构造函数
		 * \param[in] fullPath XML文件全路径名称
		 **/
		public Parameter(string fullPath)
		{
			m_fullPath = fullPath;
			m_docXML = new XmlDocument();
			CheckFileExist();
		}

		// 析构函数
		~Parameter()
		{
			try
			{
				if (m_bModified && m_docXML != null) {
					m_docXML.Save(m_fullPath);
				}
			}
			catch
			{
				MessageBox.Show("Failed to Save XML file.");
			}
		}

		/*!
		 * \fn string GetParamValue(string sectionName, string keyName, string defaultValue)
		 * \brief 检查sectionName-KeyName的对应值
		 * \param[in] sectionName  区域名称
		 * \param[in] keyName      键名称
		 * \param[in] defaultValue 缺省值
		 * \return
		 * 如果sectionName不存在, 则创建并返回缺省值
		 * 如果keyName不存在, 则返回缺省值
		 * 否则返回对应值
		 **/
		public string GetValue(string sectionName, string keyName, string defaultValue)
		{
			if (!IsSectionExist(sectionName))
				return defaultValue;
			// 遍历section, 查看keyword==keyname的节点, 若找到则返回其值
			XmlNode root = m_docXML.DocumentElement;
			XmlNodeList nodelist = root.SelectSingleNode(sectionName).ChildNodes;
			foreach (XmlNode node in nodelist)
			{
				if (node.NodeType != XmlNodeType.Element)
					continue;
				XmlElement element = (XmlElement)node;
				if (element.GetAttribute("Keyword") == keyName)
					return element.GetAttribute("Value");
			}
			// 否则为keyname-defaultvalue建立记录
			XmlNode section = root.SelectSingleNode(sectionName);
			XmlElement newxe = m_docXML.CreateElement("Add");
			newxe.SetAttribute("Keyword", keyName);
			newxe.SetAttribute("Value", defaultValue);
			section.AppendChild(newxe);
			m_bModified = true;

			return defaultValue;
		}

		public void SetValue(string sectionName, string keyName, string value)
		{
			// 检查Section是否存在, 若不存在则创建
			IsSectionExist(sectionName);
			// 遍历Section, 查找Keyword==keyName的节点, 若找到则更改其值
			XmlNode root = m_docXML.DocumentElement;
			XmlNodeList nodelist = root.SelectSingleNode(sectionName).ChildNodes;
			foreach (XmlNode node in nodelist)
			{
				if (node.NodeType != XmlNodeType.Element) continue;
				XmlElement element = (XmlElement) node;
				if (element.GetAttribute("Keyword") == keyName) {
					element.SetAttribute("Value", value);
					m_bModified = true;
					return;
				}
			}
			// 否则创建keyName-value对
			XmlNode section = root.SelectSingleNode(sectionName);
			XmlElement newxe = m_docXML.CreateElement("Add");
			newxe.SetAttribute("Keyword", keyName);
			newxe.SetAttribute("Value", value);
			section.AppendChild(newxe);
			m_bModified = true;
		}

		/*!
		 * \fn void CheckFileExist()
		 * \brief 检查指定的XML文件是否存在
		 * \return
		 * 如果不存在则创建空XML文件, 并当创建失败时返回false, 否则返回true
		 **/
		private void CheckFileExist()
		{
			if (File.Exists(m_fullPath))
			{
				m_docXML.Load(m_fullPath);
			}
			else
			{
				// 创建XML文件
				XmlNode node = m_docXML.CreateNode(XmlNodeType.XmlDeclaration, "", "");
				m_docXML.AppendChild(node);
				// 创建根节点
				XmlNode node1 = m_docXML.CreateNode(XmlNodeType.Element, "Configuration", "");
				m_docXML.AppendChild(node1);
			}
		}

		/* 检查sectionName对应的section是否存在, 如不存在则追加 */
		private bool IsSectionExist(string sectionName)
		{
			bool bReturn = true;
			bool bFound = false;

			try
			{
				XmlNodeList nlist = m_docXML.SelectSingleNode("Configuration").ChildNodes;
				foreach (XmlNode node in nlist)
				{// 不存在, 需要创建section
					if (node.NodeType != XmlNodeType.Element) continue;
					if (node.Name == sectionName) {
						bFound = true;
						break;
					}
				}
				if (!bFound)
				{// 没有找到, 需要创建
					XmlNode root = m_docXML.SelectSingleNode("Configuration");
					XmlNode nnode = m_docXML.CreateNode(XmlNodeType.Element, sectionName, "");
					root.AppendChild(nnode);

					XmlNode nspace = m_docXML.CreateWhitespace("\r\n");
					root.AppendChild(nspace);

					m_bModified = true;

				}
			}
			catch (XPathException xpe)
			{
				bReturn = false;
				MessageBox.Show(xpe.Message);
			}

			return bReturn;
		}
	}
}
