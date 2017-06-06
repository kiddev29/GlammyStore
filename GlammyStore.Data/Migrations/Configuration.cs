﻿namespace GlammyStore.Data.Migrations
{
    using Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GlammyStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GlammyStoreDbContext context)
        {
            CreateUser(context);
            BrandDefault(context);
            CreateContactDetail(context);
            CreateSystemConfig(context);
            CreatePage(context);
            CreateGroup(context);
        }
        #region Methods
        private void CreateUser(GlammyStoreDbContext context)
        {
            if (context.Users.Count() == 0)
            {
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new GlammyStoreDbContext()));

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new GlammyStoreDbContext()));

                var user = new ApplicationUser()
                {
                    UserName = "dvbtham",
                    Email = "dvbtham@gmail.com",
                    EmailConfirmed = true,
                    Image = CommonConstants.DefaultAvatar,
                    CreatedDate = DateTime.Now,
                    BirthDay = DateTime.ParseExact("15/09/1996", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Gender = "Nam",
                    FullName = "Thâm David",
                    Address = "Gia Lai",
                    PhoneNumber = "01652130546",
                    IsDeleted = false,
                    IsViewed = true
                };
                if (manager.Users.Count() == 0)
                {
                    manager.Create(user, "123123$");

                    if (!roleManager.Roles.Any())
                    {
                        roleManager.Create(new IdentityRole { Name = "Admin" });
                        roleManager.Create(new IdentityRole { Name = "User" });
                    }

                    var adminUser = manager.FindByEmail("dvbtham@gmail.com");

                    manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });

                }
            }
        }

        private void BrandDefault(GlammyStoreDbContext context)
        {
            if (context.Brands.Count() == 0)
            {
                var brand = new Brand()
                {
                    Name = "Apple",
                    Alias = "apple",
                    CreatedBy = "system",
                    CreatedDate = DateTime.Now,
                    Status = true,
                    IsDeleted = false
                };
                context.Brands.Add(brand);
                context.SaveChanges();
            }
        }

        private void CreateContactDetail(GlammyStoreDbContext context)
        {
            if (context.ContactDetails.Count() == 0)
            {
                try
                {
                    var contactDetail = new ContactDetail()
                    {
                        Name = "Shop online - GlammyStore",
                        Address = "472 Núi Thành",
                        Phone = "016 5213 0546",
                        Email = "dvbtham@gmail.com",
                        Lat = 16.034562,
                        Lng = 108.222603,
                        Website = "http://GlammyStore.somee.com",
                        Description = "",
                        Status = true
                    };
                    context.ContactDetails.Add(contactDetail);
                    context.SaveChanges();
                }
                catch
                {

                }
            }
        }

        private void CreateSystemConfig(GlammyStoreDbContext context)
        {
            if (!context.SystemConfigs.Any(x => x.Code == "Hometitle"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeTitle",
                    ValueString = "Trang chủ GlammyStore shop - nơi mua bán uy tín và chất lượng - GlammyStore.com"
                });
            }
            if (!context.SystemConfigs.Any(x => x.Code == "HomeMetaKeyword"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeMetaKeyword",
                    ValueString = "Trang chủ GlammyStore shop - nơi mua bán uy tín và chất lượng - GlammyStore.com"
                });
            }
            if (!context.SystemConfigs.Any(x => x.Code == "HomeMetaDescription"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeMetaDescription",
                    ValueString = "Trang chủ GlammyStore shop - nơi mua bán uy tín và chất lượng - GlammyStore.com"
                });
            }
        }

        private void CreatePage(GlammyStoreDbContext context)
        {
            if (context.Pages.Count() == 0)
            {
                try
                {
                    var page = new Page()
                    {
                        Name = "Giới thiệu",
                        Alias = "gioi-thieu",
                        CreatedDate = DateTime.Now,
                        MetaDescription = "Trang giới thiệu của GlammyStore",
                        MetaKeyword = "Trang giới thiệu của GlammyStore",
                        Content = @"Là trang web bán hàng online, chuyên cung cấp món hàng trong lĩnh vực thiết bị số: Điện thoại, máy tính cá nhân, máy ảnh,... và một số dịch vụ kèm theo khi mua hàng.",
                        Status = true

                    };
                    context.Pages.Add(page);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }

            }
        }

        private void CreateGroup(GlammyStoreDbContext context)
        {
            if (context.ApplicationGroups.Count() == 0)
            {
                try
                {
                    var appGroups = new List<ApplicationGroup>();

                    appGroups.Add(new ApplicationGroup()
                    {
                        Name = "Admin",
                        Description = "Ban quản trị",
                        IsDeleted = false
                    });
                    appGroups.Add(new ApplicationGroup()
                    {
                        Name = "Người quản lý",
                        Description = "Người quản lý",
                        IsDeleted = false
                    });
                    appGroups.Add(new ApplicationGroup()
                    {
                        Name = "Thành viên",
                        Description = "Thành viên",
                        IsDeleted = false
                    });
                    appGroups.Add(new ApplicationGroup()
                    {
                        Name = "Tài xế",
                        Description = "Tài xế",
                        IsDeleted = false
                    });

                    foreach (var appGroup in appGroups)
                    {
                        context.ApplicationGroups.Add(appGroup);
                        context.SaveChanges();
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
        }
        #endregion
    }
}