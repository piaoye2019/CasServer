// ***********************************************************************************
//  Created by zbw911 
//  �����ڣ�2013��06��03�� 16:48
//  
//  �޸��ڣ�2013��06��03�� 17:25
//  �ļ�����CASServer/Domain.Entities/webpages_OAuthMembershipMap.cs
//  
//  ����и��õĽ����������ʼ��� zbw911#gmail.com
// ***********************************************************************************

using System.Data.Entity.ModelConfiguration;

namespace Domain.Entities.Models.Mapping
{
    public class webpages_OAuthMembershipMap : EntityTypeConfiguration<webpages_OAuthMembership>
    {
        #region C'tors

        public webpages_OAuthMembershipMap()
        {
            // Primary Key
            this.HasKey(t => new {t.Provider, t.ProviderUserId});

            // Properties
            this.Property(t => t.Provider)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.ProviderUserId)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("webpages_OAuthMembership");
            this.Property(t => t.Provider).HasColumnName("Provider");
            this.Property(t => t.ProviderUserId).HasColumnName("ProviderUserId");
            this.Property(t => t.UserId).HasColumnName("UserId");
        }

        #endregion
    }
}