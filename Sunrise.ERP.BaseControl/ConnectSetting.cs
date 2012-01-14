//-------------------------------------------------------------------------------------------
//Name:             Sunrise.ERP.BaseForm.ConnectSetting
//Description:      数据库连接设置及操作类
//Create by:        Belself.Wang
//Create Date:      2010-7-24
//Modify by：              Modify Date：               Description：  
//Modify by：              Modify Date：               Description：  
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Xml;

using Sunrise.ERP.Lang;

namespace Sunrise.ERP.BaseControl
{
    /// <summary>
    /// 数据库连接设置及操作类
    /// </summary>
    public class ConnectSetting
    {
        private static SqlConnection _conn;
        /// <summary>
        /// 系统数据库连接
        /// </summary>
        public static SqlConnection SysSqlConnection
        {
            get
            {
                if (_conn != null)
                {
                    if (_conn.State != ConnectionState.Open)
                    {
                        _conn.Open();
                    }
                    return _conn;
                }
                else
                {
                    _conn=new SqlConnection(GetSqlConnString());
                    _conn.Open();
                    return _conn;
                }
            }
            set
            {
                _conn = value;
            }
        }

        /// <summary>
        /// 获取SQL连接字符串
        /// </summary>
        /// <returns>SQL连接字符串</returns>
        public static string GetSqlConnString()
        {
            return "Data Source=" + GetAppConfig("ServerName",true) + ";Initial Catalog=" + GetAppConfig("DataBase",true) + ";User ID=" + GetAppConfig("UserName",true) + ";Password=" + GetAppConfig("Password",true);
        }

        /// <summary>
        /// 保存数据库连接设置
        /// </summary>
        /// <param name="server">服务器名称</param>
        /// <param name="database">数据库名称</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        public static void SaveSqlConnString(string server, string database, string username, string password)
        {
            try
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //数据库服务器
                if (config.AppSettings.Settings["ServerName"] == null)
                {
                    config.AppSettings.Settings.Add("ServerName", SysEncrypt.EncryptStr(server));
                }
                else
                {
                    config.AppSettings.Settings["ServerName"].Value = SysEncrypt.EncryptStr(server);
                }
                //数据库名称
                if (config.AppSettings.Settings["DataBase"] == null)
                {
                    config.AppSettings.Settings.Add("DataBase", SysEncrypt.EncryptStr(database));
                }
                else
                {
                    config.AppSettings.Settings["DataBase"].Value = SysEncrypt.EncryptStr(database);
                }
                //用户名
                if (config.AppSettings.Settings["UserName"] == null)
                {
                    config.AppSettings.Settings.Add("UserName", SysEncrypt.EncryptStr(username));
                }
                else
                {
                    config.AppSettings.Settings["UserName"].Value = SysEncrypt.EncryptStr(username);
                }
                //密码
                if (config.AppSettings.Settings["Password"] == null)
                {
                    config.AppSettings.Settings.Add("Password", SysEncrypt.EncryptStr(password));
                }
                else
                {
                    config.AppSettings.Settings["Password"].Value = SysEncrypt.EncryptStr(password);
                }
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");//重新加载新的配置文件 
                //重新设置系统数据库连接
                SysSqlConnection = new SqlConnection(GetSqlConnString());

            }
            catch
            {
                Public.SystemInfo(LangCenter.Instance.GetSystemMessage("SaveConfigFileFailed"), true);
            }
        }

        /// <summary>
        /// 保存信息至配置文件
        /// </summary>
        /// <param name="keyname">节点名称</param>
        /// <param name="keyvalue">节点值</param>
        /// <param name="isencript">是否加密</param>
        public static void SaveAppConfig(string keyname, string keyvalue, bool isencript)
        {
            try
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (isencript)
                {
                    if (config.AppSettings.Settings[keyname] == null)
                    {
                        config.AppSettings.Settings.Add(keyname, SysEncrypt.EncryptStr(keyvalue));
                    }
                    else
                    {
                        config.AppSettings.Settings[keyname].Value = SysEncrypt.EncryptStr(keyvalue);
                    }
                }
                else
                {
                    if (config.AppSettings.Settings[keyname] == null)
                    {
                        config.AppSettings.Settings.Add(keyname, keyvalue);
                    }
                    else
                    {
                        config.AppSettings.Settings[keyname].Value = keyvalue;
                    }
                }
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");//重新加载新的配置文件 

            }
            catch
            {
                //Public.SystemInfo("写配置文件失败！", true);
            }
        }

        /// <summary>
        /// 取得具体的连接字符串名称
        /// </summary>
        /// <param name="keyName">配置文件中的Key Name</param>
        /// <param name="isencript">是否加密</param>
        /// <returns></returns>
        public static string GetAppConfig(string keyName,bool isencript)
        {
            string sResult = "";
            try
            {
                if (ConfigurationManager.AppSettings[keyName] != "")
                {
                    if (isencript)
                    {
                        sResult = SysEncrypt.DecryptStr(ConfigurationManager.AppSettings[keyName]);
                        if (sResult == "KeyError")
                        {
                            sResult = "";
                        }
                    }
                    else
                    {
                        sResult = ConfigurationManager.AppSettings[keyName];
                    }
                }
                return sResult;
            }
            catch
            {
                Public.SystemInfo(LangCenter.Instance.GetSystemMessage("GetConnectStringFailed"), true);
                return sResult;
            }
        }
    }
}
