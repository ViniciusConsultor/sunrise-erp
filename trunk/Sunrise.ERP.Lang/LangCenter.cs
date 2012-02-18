using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace Sunrise.ERP.Lang
{
    /// <summary>
    /// 系统语言设置处理类
    /// </summary>
    public sealed class LangCenter
    {
        public LangCenter()
        {

        }
        #region 属性
        private XmlDocument _langXmlDocument = new XmlDocument();
        /// <summary>
        /// 语言资源文件
        /// </summary>
        private XmlDocument LangXmlDocument
        {
            get
            {
                return _langXmlDocument;
            }
            set
            {
                _langXmlDocument = value;
            }
        }
        public static LangCenter Instance
        {
            get
            {
                return Nested.instance;
            }
        }


        class Nested
        {
            static Nested()
            {
            }

            internal static readonly LangCenter instance = new LangCenter();
        }

        /// <summary>
        /// 语言资源文件路径
        /// </summary>
        private string LangSourcePath
        {
            get { return Application.StartupPath + @"\lang\{0}.lang"; }
        }
        private static bool _isdefaultlanguage;
        /// <summary>
        /// 当前系统语音是否为默认语言
        /// </summary>
        public bool IsDefaultLanguage
        {
            get { return _isdefaultlanguage; }
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 加载语言资源文件
        /// </summary>
        /// <param name="lang">语言</param>
        /// <returns></returns>
        public void LoadLangXmlDocument(string lang)
        {
            try
            {
                _isdefaultlanguage = lang == "default";
                LangXmlDocument.Load(string.Format(LangSourcePath, lang));
            }
            catch { }
        }

        /// <summary>
        /// 返回语言信息
        /// </summary>
        /// <param name="LangPath">语言XML模块</param>
        /// <param name="LangModule">语言模块名称</param>
        /// <param name="LangLabel">语言标签名称</param>
        /// <returns></returns>
        public string GetLangText(string LangPath, string LangModule, string LangLabel)
        {
            string msg = string.Empty;
            string lang = LangXmlDocument.DocumentElement.Attributes[0].Value;
            if (LangXmlDocument != null)
            {
                string MessageXPath = LangModule != "" ? "/Lang/" + LangPath + "/" + LangModule + "/" + LangLabel : "/Lang/" + LangPath + "/" + LangLabel;
                msg = LangXmlDocument.SelectNodes(MessageXPath)[0].Attributes["value"].Value;
            }
            return msg;
        }

        /// <summary>
        /// 返回系统提示信息
        /// </summary>
        /// <param name="MessageName">消息名称</param>
        /// <returns></returns>
        public string GetSystemMessage(string MessageName)
        {
            return GetLangText("SystemMessage", "", MessageName);
        }

        /// <summary>
        /// 返回窗体语言信息
        /// </summary>
        /// <param name="FormName">窗体名称</param>
        /// <param name="ControlName">控件名称</param>
        /// <returns></returns>
        public string GetFormLangInfo(string FormName, string LableName)
        {
            return GetLangText("FormLang", FormName, LableName);
        }

        public string GetControlLangInfo(string ControlName, string LabelName)
        {
            return GetLangText("FormControls", ControlName, LabelName);
        }


        #endregion
    }
}

