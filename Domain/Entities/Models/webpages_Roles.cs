// ***********************************************************************************
//  Created by zbw911 
//  �����ڣ�2013��06��03�� 16:48
//  
//  �޸��ڣ�2013��06��03�� 17:25
//  �ļ�����CASServer/Domain.Entities/webpages_Roles.cs
//  
//  ����и��õĽ����������ʼ��� zbw911#gmail.com
// ***********************************************************************************

using System.Collections.Generic;

namespace Domain.Entities.Models
{
    public partial class webpages_Roles
    {
        #region C'tors

        public webpages_Roles()
        {
            this.webpages_UsersInRoles = new List<webpages_UsersInRoles>();
        }

        #endregion

        #region Instance Properties

        public virtual ICollection<webpages_UsersInRoles> webpages_UsersInRoles { get; set; }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        #endregion
    }
}