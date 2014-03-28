// ***********************************************************************************
//  Created by zbw911 
//  �����ڣ�2013��06��03�� 16:48
//  
//  �޸��ڣ�2013��06��03�� 17:25
//  �ļ�����CASServer/Domain.Entities/passportContext.cs
//  
//  ����и��õĽ����������ʼ��� zbw911#gmail.com
// ***********************************************************************************

using System.Data.Entity;
using Domain.Entities.Models.Mapping;

namespace Domain.Entities.Models
{
    public partial class passportContext : DbContext
    {
        #region C'tors

        static passportContext()
        {
            Database.SetInitializer<passportContext>(null);
        }

        public passportContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        #endregion

        #region Instance Properties

        public DbSet<UserExtend> UserExtends { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<webpages_Membership> webpages_Membership { get; set; }
        public DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public DbSet<webpages_Roles> webpages_Roles { get; set; }
        public DbSet<webpages_UsersInRoles> webpages_UsersInRoles { get; set; }

        #endregion

        #region Instance Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new UserExtendMap());
            modelBuilder.Configurations.Add(new UserProfileMap());
            modelBuilder.Configurations.Add(new webpages_MembershipMap());
            modelBuilder.Configurations.Add(new webpages_OAuthMembershipMap());
            modelBuilder.Configurations.Add(new webpages_RolesMap());
            modelBuilder.Configurations.Add(new webpages_UsersInRolesMap());
        }

        #endregion
    }
}