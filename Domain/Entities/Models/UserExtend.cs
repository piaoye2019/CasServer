// ***********************************************************************************
//  Created by zbw911 
//  �����ڣ�2013��06��03�� 16:48
//  
//  �޸��ڣ�2013��06��03�� 17:25
//  �ļ�����CASServer/Domain.Entities/UserExtend.cs
//  
//  ����и��õĽ����������ʼ��� zbw911#gmail.com
// ***********************************************************************************

using System.Collections.Generic;

namespace Domain.Entities.Models
{
    public partial class UserExtend
    {
        #region C'tors

        public UserExtend()
        {
            this.webpages_UsersInRoles = new List<webpages_UsersInRoles>();
        }

        #endregion

        #region Instance Properties

        public virtual ICollection<webpages_UsersInRoles> webpages_UsersInRoles { get; set; }
        public decimal Uid { get; set; }
        public int UserId { get; set; }

        #endregion
    }
}