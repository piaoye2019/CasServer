// ***********************************************************************************
//  Created by zbw911 
//  �����ڣ�2013��06��03�� 16:48
//  
//  �޸��ڣ�2013��06��03�� 17:25
//  �ļ�����CASServer/Domain.Entities/webpages_OAuthMembership.cs
//  
//  ����и��õĽ����������ʼ��� zbw911#gmail.com
// ***********************************************************************************

namespace Domain.Entities.Models
{
    public partial class webpages_OAuthMembership
    {
        #region Instance Properties

        public string Provider { get; set; }
        public string ProviderUserId { get; set; }
        public int UserId { get; set; }

        #endregion
    }
}