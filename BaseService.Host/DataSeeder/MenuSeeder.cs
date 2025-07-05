using System;
using System.Collections.Generic;
using BaseService.Systems;

namespace BaseService.DataSeeder
{
    public class MenuSeeder
    {
        public List<Menu> GetSeed()
        {
            var seed = new List<Menu>();

            var dashboard = new Menu(Guid.NewGuid()) { CategoryId = 1, Name = "dashboard", Label = "統計數據", Sort = 2, Path = "/dashboard", Component = "Layout", Icon = "dashboard", AlwaysShow = true };
            var chart = new Menu(Guid.NewGuid()) { Pid = dashboard.Id, CategoryId = 1, Name = "chart", Label = "儀錶板", Sort = 3, Path = "chart", Component = "chart/index", Permission = "Business.TaskDashboard", Icon = "user" };
            seed.Add(new Menu(Guid.NewGuid()) { Pid = chart.Id, CategoryId = 2, Name = "Create", Label = "新增", Sort = 3, Permission = "Business.TaskDashboard.Create", Icon = "create", Hidden = true });
            seed.Add(new Menu(Guid.NewGuid()) { Pid = chart.Id, CategoryId = 2, Name = "Update", Label = "修改", Sort = 3, Permission = "Business.TaskDashboard.Update", Icon = "update", Hidden = true });
            seed.Add(new Menu(Guid.NewGuid()) { Pid = chart.Id, CategoryId = 2, Name = "Delete", Label = "删除", Sort = 3, Permission = "Business.TaskDashboard.Delete", Icon = "delete", Hidden = true });

            //首頁
            var index = new Menu(Guid.NewGuid()) { CategoryId = 1, Name = "index", Label = "首頁", Sort = 1, Path = "/index", Component = "Layout", Icon = "dashboard", AlwaysShow = true};
            var overview = new Menu(Guid.NewGuid()) { Pid = index.Id, CategoryId = 1, Name = "calendar", Label = "月曆", Sort = 10, Path = "calendar", Component = "index/calendar", Icon = "data" };
            seed.Add(index);
            seed.Add(overview); 
            seed.Add(dashboard);
            seed.Add(chart); 

            var mission = new Menu(Guid.NewGuid()) { CategoryId = 1, Name = "mission", Label = "任務管理", Sort = 3, Path = "/mission", Component = "Layout", Icon = "base", AlwaysShow = true };
            var category = new Menu(Guid.NewGuid()) { Pid = mission.Id, CategoryId = 1, Name = "category", Label = "任務類別", Sort = 10, Path = "category", Component = "category/index", Permission = "Business.TaskCategory", Icon = "book" };
            seed.Add(new Menu(Guid.NewGuid()) { Pid = category.Id, CategoryId = 2, Name = "Create", Label = "新增", Sort = 3, Permission = "Business.TaskCategory.Create", Icon = "create", Hidden = true });
            seed.Add(new Menu(Guid.NewGuid()) { Pid = category.Id, CategoryId = 2, Name = "Update", Label = "修改", Sort = 3, Permission = "Business.TaskCategory.Update", Icon = "update", Hidden = true });
            seed.Add(new Menu(Guid.NewGuid()) { Pid = category.Id, CategoryId = 2, Name = "Delete", Label = "删除", Sort = 3, Permission = "Business.TaskCategory.Delete", Icon = "delete", Hidden = true });

            var item = new Menu(Guid.NewGuid()) { Pid = mission.Id, CategoryId = 1, Name = "item", Label = "任務項目", Sort = 9, Path = "item", Component = "item/index", Permission = "Business.TaskItem", Icon = "printer" };
            seed.Add(new Menu(Guid.NewGuid()) { Pid = item.Id, CategoryId = 2, Name = "Create", Label = "新增", Sort = 3, Permission = "Business.TaskItem.Create", Icon = "create", Hidden = true });
            seed.Add(new Menu(Guid.NewGuid()) { Pid = item.Id, CategoryId = 2, Name = "Update", Label = "修改", Sort = 3, Permission = "Business.TaskItem.Update", Icon = "update", Hidden = true });
            seed.Add(new Menu(Guid.NewGuid()) { Pid = item.Id, CategoryId = 2, Name = "Delete", Label = "删除", Sort = 3, Permission = "Business.TaskItemDelete", Icon = "delete", Hidden = true });
            seed.Add(mission); seed.Add(category); seed.Add(item);

            return seed;
        }

        public List<Menu> GetVue3Seed()
        {
            var seed = new List<Menu>();

            var home = new Menu(Guid.NewGuid()) { CategoryId = 1, Name = "home", Label = "首页", Sort = 1, Path = "/home", Component = "Layout", Icon = "ele-House", IsHost = true, Title = "message.router.home" };
            var calendar = new Menu(Guid.NewGuid()) { Pid = home.Id, CategoryId = 1, Name = "calendar", Label = "工作台", Sort = 1, Path = "/home/calendar", Component = "/home/index", Icon = "ele-HomeFilled", IsHost = true, Title = "message.router.dashboard", IsAffix = true };
            seed.Add(home); seed.Add(calendar);

            var dashboard = new Menu(Guid.NewGuid()) { CategoryId = 1, Name = "dashboard", Label = "統計數據", Sort = 2, Path = "/dashboard", Component = "Layout", Icon = "ele-Setting", AlwaysShow = true, Title = "message.router.systemManagement" };
            var chart = new Menu(Guid.NewGuid()) { Pid = dashboard.Id, CategoryId = 1, Name = "chart", Label = "儀錶板", Sort = 3, Path = "/dashboard/chart", Component = "/dashboard/chart/index", Permission = "AbpIdentity.Users", Icon = "iconfont icon-icon-", Title = "message.router.user" };
            seed.Add(dashboard);
            seed.Add(chart); 

            var mission = new Menu(Guid.NewGuid()) { CategoryId = 1, Name = "mission", Label = "基础资料", Sort = 3, Path = "/mission", Component = "Layout", Icon = "base", AlwaysShow = true, Title = "message.router.base" };
            var category = new Menu(Guid.NewGuid()) { Pid = mission.Id, CategoryId = 1, Name = "category", Label = "Book", Sort = 10, Path = "category", Component = "category/index", Permission = "Business.Book", Icon = "book" };
            seed.Add(new Menu(Guid.NewGuid()) { Pid = category.Id, CategoryId = 2, Name = "Create", Label = "新增", Sort = 3, Permission = "Business.Book.Create", Icon = "create", Hidden = true });
            seed.Add(new Menu(Guid.NewGuid()) { Pid = category.Id, CategoryId = 2, Name = "Update", Label = "修改", Sort = 3, Permission = "Business.Book.Update", Icon = "update", Hidden = true });
            seed.Add(new Menu(Guid.NewGuid()) { Pid = category.Id, CategoryId = 2, Name = "Delete", Label = "删除", Sort = 3, Permission = "Business.Book.Delete", Icon = "delete", Hidden = true });

            var item = new Menu(Guid.NewGuid()) { Pid = mission.Id, CategoryId = 1, Name = "item", Label = "打印模板", Sort = 9, Path = "item", Component = "item/index", Permission = "Business.PrintTemplate", Icon = "printer", Title = "message.router.print" };
            seed.Add(new Menu(Guid.NewGuid()) { Pid = item.Id, CategoryId = 2, Name = "Create", Label = "新增", Sort = 3, Permission = "Business.PrintTemplate", Icon = "create", Hidden = true });
            seed.Add(new Menu(Guid.NewGuid()) { Pid = item.Id, CategoryId = 2, Name = "Update", Label = "修改", Sort = 3, Permission = "Business.PrintTemplate.Update", Icon = "update", Hidden = true });
            seed.Add(new Menu(Guid.NewGuid()) { Pid = item.Id, CategoryId = 2, Name = "Delete", Label = "删除", Sort = 3, Permission = "Business.PrintTemplate.Delete", Icon = "delete", Hidden = true });
            seed.Add(mission); seed.Add(category); seed.Add(item);

            return seed;
        }
    }
}
