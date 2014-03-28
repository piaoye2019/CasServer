// ***********************************************************************************
//  Created by zbw911 
//  �����ڣ�2013��06��03�� 16:48
//  
//  �޸��ڣ�2013��06��03�� 17:25
//  �ļ�����CASServer/Domain.Entities/webpages_Membership.cs
//  
//  ����и��õĽ����������ʼ��� zbw911#gmail.com
// ***********************************************************************************

using System;

namespace Domain.Entities.Models
{
    public partial class webpages_Membership
    {
        #region Instance Properties

        public string ConfirmationToken { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<bool> IsConfirmed { get; set; }
        public Nullable<System.DateTime> LastPasswordFailureDate { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> PasswordChangedDate { get; set; }
        public int PasswordFailuresSinceLastSuccess { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordVerificationToken { get; set; }
        public Nullable<System.DateTime> PasswordVerificationTokenExpirationDate { get; set; }
        public int UserId { get; set; }

        #endregion
    }
}