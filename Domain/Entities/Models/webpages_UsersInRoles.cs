// ***********************************************************************************
//  Created by zbw911 
//  �����ڣ�2013��06��03�� 16:48
//  
//  �޸��ڣ�2013��06��03�� 17:25
//  �ļ�����CASServer/Domain.Entities/webpages_UsersInRoles.cs
//  
//  ����и��õĽ����������ʼ��� zbw911#gmail.com
// ***********************************************************************************

namespace Domain.Entities.Models
{
    public partial class webpages_UsersInRoles
    {
        #region Instance Properties

        public virtual UserExtend UserExtend { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual webpages_Roles webpages_Roles { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }

        #endregion
    }
}