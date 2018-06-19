using System.Collections.Generic;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Service.Interfaces
{
    public interface IApplicationGroupService
    {
        ApplicationGroup GetDetail(int id);

        IEnumerable<ApplicationGroup> GetAll(int page, int pageSize, out int totalRow, string filter);

        IEnumerable<ApplicationGroup> GetAll();

        ApplicationGroup Add(ApplicationGroup appGroup);

        void Update(ApplicationGroup appGroup);

        ApplicationGroup Delete(int id);

        bool AddUserToGroups(IEnumerable<ApplicationUserGroup> groups, string userId);

        IEnumerable<ApplicationGroup> GetListGroupByUserId(string userId);

        IEnumerable<ApplicationUser> GetListUserByGroupId(int groupId);

        void Save();
    }
}
