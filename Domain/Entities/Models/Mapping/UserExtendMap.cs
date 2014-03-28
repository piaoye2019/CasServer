// ***********************************************************************************
//  Created by zbw911 
//  �����ڣ�2013��06��03�� 16:48
//  
//  �޸��ڣ�2013��06��03�� 17:25
//  �ļ�����CASServer/Domain.Entities/UserExtendMap.cs
//  
//  ����и��õĽ����������ʼ��� zbw911#gmail.com
// ***********************************************************************************

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Entities.Models.Mapping
{
    public class UserExtendMap : EntityTypeConfiguration<UserExtend>
    {
        #region C'tors

        public UserExtendMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);

            // Properties
            this.Property(t => t.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Uid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasPrecision(11, 0);

            // Table & Column Mappings
            this.ToTable("UserExtend");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Uid).HasColumnName("Uid");
        }

        #endregion
    }
}