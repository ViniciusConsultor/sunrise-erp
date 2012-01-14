//-------------------------------------------------------------------------------------------
//Name:             Sunrise.ERP.BaseForm.ConnectSetting
//Description:      ���ݿ��������ü�������
//Create by:        Belself.Wang
//Create Date:      2010-7-24
//Modify by��              Modify Date��               Description��  
//Modify by��              Modify Date��               Description��  
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
    /// ���ݿ��������ü�������
    /// </summary>
    public class ConnectSetting
    {
        private static SqlConnection _conn;
        /// <summary>
        /// ϵͳ���ݿ�����
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
        /// ��ȡSQL�����ַ���
        /// </summary>
        /// <returns>SQL�����ַ���</returns>
        public static string GetSqlConnString()
        {
            return "Data Source=" + GetAppConfig("ServerName",true) + ";Initial Catalog=" + GetAppConfig("DataBase",true) + ";User ID=" + GetAppConfig("UserName",true) + ";Password=" + GetAppConfig("Password",true);
        }

        /// <summary>
        /// �������ݿ���������
        /// </summary>
        /// <param name="server">����������</param>
        /// <param name="database">���ݿ�����</param>
        /// <param name="username">�û���</param>
        /// <param name="password">����</param>
        public static void SaveSqlConnString(string server, string database, string username, string password)
        {
            try
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //���ݿ������
                if (config.AppSettings.Settings["ServerName"] == null)
                {
                    config.AppSettings.Settings.Add("ServerName", SysEncrypt.EncryptStr(server));
                }
                else
                {
                    config.AppSettings.Settings["ServerName"].Value = SysEncrypt.EncryptStr(server);
                }
                //���ݿ�����
                if (config.AppSettings.Settings["DataBase"] == null)
                {
                    config.AppSettings.Settings.Add("DataBase", SysEncrypt.EncryptStr(database));
                }
                else
                {
                    config.AppSettings.Settings["DataBase"].Value = SysEncrypt.EncryptStr(database);
                }
                //�û���
                if (config.AppSettings.Settings["UserName"] == null)
                {
                    config.AppSettings.Settings.Add("UserName", SysEncrypt.EncryptStr(username));
                }
                else
                {
                    config.AppSettings.Settings["UserName"].Value = SysEncrypt.EncryptStr(username);
                }
                //����
                if (config.AppSettings.Settings["Password"] == null)
                {
                    config.AppSettings.Settings.Add("Password", SysEncrypt.EncryptStr(password));
                }
                else
                {
                    config.AppSettings.Settings["Password"].Value = SysEncrypt.EncryptStr(password);
                }
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");//���¼����µ������ļ� 
                //��������ϵͳ���ݿ�����
                SysSqlConnection = new SqlConnection(GetSqlConnString());

            }
            catch
            {
                Public.SystemInfo(LangCenter.Instance.GetSystemMessage("SaveConfigFileFailed"), true);
            }
        }

        /// <summary>
        /// ������Ϣ�������ļ�
        /// </summary>
        /// <param name="keyname">�ڵ�����</param>
        /// <param name="keyvalue">�ڵ�ֵ</param>
        /// <param name="isencript">�Ƿ����</param>
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
                ConfigurationManager.RefreshSection("appSettings");//���¼����µ������ļ� 

            }
            catch
            {
                //Public.SystemInfo("д�����ļ�ʧ�ܣ�", true);
            }
        }

        /// <summary>
        /// ȡ�þ���������ַ�������
        /// </summary>
        /// <param name="keyName">�����ļ��е�Key Name</param>
        /// <param name="isencript">�Ƿ����</param>
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
