// ***********************************************************************************
//  Created by zbw911 
//  �����ڣ�2013��06��03�� 16:48
//  
//  �޸��ڣ�2013��06��03�� 17:25
//  �ļ�����CASServer/Application.Config/CommConfiguration.cs
//  
//  ����и��õĽ����������ʼ��� zbw911#gmail.com
// ***********************************************************************************

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Application.Config
{
    [DataContract]
    public class CommConfiguration
    {
        #region Readonly & Static Fields

        private static CommConfiguration _config;
        private static IConfigurationStorage _configProvider;

        #endregion

        #region Fields

        /// <summary>
        ///   ���Žӿڵ�ַ
        /// </summary>
        [DataMember] public string SmsApi;

        #endregion

        #region Instance Properties

        /// <summary>
        ///   Ĭ�ϵ���ҳ��
        /// </summary>
        //[DataMember]
        public string CurrentUrl { get; set; }

        /// <summary>
        ///   XXXXX�ṩ��API
        /// </summary>
        [DataMember]
        public string TuanApibase { get; set; }

        #endregion

        #region Class Properties

        public static CommConfiguration Config
        {
            get
            {
                if (_config == null)
                    _config = ConfigProvider.Get();
                return _config;
            }
            set
            {
                _config = value;
                ConfigProvider.Save(_config);
            }
        }

        [XmlIgnore]
        public static IConfigurationStorage ConfigProvider
        {
            get
            {
                if (_configProvider == null)
                    _configProvider = new XmlConfigurationStorage();
                return _configProvider;
            }
            set { _configProvider = value; }
        }

        #endregion
    }
}