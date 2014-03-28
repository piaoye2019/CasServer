// ***********************************************************************************
//  Created by zbw911 
//  �����ڣ�2013��06��03�� 16:48
//  
//  �޸��ڣ�2013��06��03�� 17:25
//  �ļ�����CASServer/Domain.Entities/UserProfile.cs
//  
//  ����и��õĽ����������ʼ��� zbw911#gmail.com
// ***********************************************************************************

using System;
using System.Collections.Generic;

namespace Domain.Entities.Models
{
    public partial class UserProfile
    {
        #region C'tors

        public UserProfile()
        {
            this.webpages_UsersInRoles = new List<webpages_UsersInRoles>();
        }

        #endregion

        #region Instance Properties

        public virtual ICollection<webpages_UsersInRoles> webpages_UsersInRoles { get; set; }
        public string Avator { get; set; }

        public Nullable<int> City { get; set; }
        public string CityName { get; set; }
        public string Email { get; set; }
        public Nullable<bool> IsConfirmEmail { get; set; }
        public Nullable<bool> IsConfirmPhone { get; set; }
        public Nullable<System.DateTime> LastPhonePasswordResetTokenTime { get; set; }
        public string NickName { get; set; }
        public string Phone { get; set; }
        public Nullable<int> PhonePasswordResendCount { get; set; }
        public string PhonePasswordResetToken { get; set; }
        public Nullable<System.DateTime> PhonePasswordResetTokenExpirationDate { get; set; }
        public Nullable<int> Province { get; set; }
        public string ProvinceName { get; set; }
        public Nullable<int> Sex { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

        #endregion
    }
}