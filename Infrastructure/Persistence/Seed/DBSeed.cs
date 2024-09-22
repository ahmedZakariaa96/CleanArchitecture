namespace Infrastructure.Persistence.Seed
{
    public static class DBSeed
    {
        public static async Task SeedData()
        {

        }
        //public static async Task SeedUsers(UserManager<User> userManager, RoleManager<Role> roleManager, IServiceProvider serviceProvider)
        //{
        //using (var serviceScope = serviceProvider.CreateScope())
        //{
        //    //create roles
        //    if (!await roleManager.Roles.AnyAsync())
        //    {
        //        foreach (var roleName in Enum.GetNames(typeof(UserRoles)))
        //        {
        //            var role = new Role { Name = roleName };
        //            await roleManager.CreateAsync(role);
        //        }
        //    }

        //    //create Admins
        //    if (!await userManager.Users.AnyAsync())
        //    {
        //        //Admin
        //        var admin = new User
        //        {
        //            UserName = "Admin01",
        //        };
        //        var x = await userManager.CreateAsync(admin, "P@ssw0rd");
        //        await userManager.AddToRoleAsync(admin, UserRoles.Admin.ToString());

        //        //Super Admin
        //        var superAdmin = new User
        //        {
        //            UserName = "SuperAdmin01"
        //        };
        //        var xx = await userManager.CreateAsync(superAdmin, "P@ssw0rd");
        //        await userManager.AddToRoleAsync(superAdmin, UserRoles.SuperAdmin.ToString());
        //    }

        //}
        //}
    }
}