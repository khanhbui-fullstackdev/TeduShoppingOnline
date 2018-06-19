using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShopingOnline.Common.Constants;
using TeduShopingOnline.Common.Exceptions;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Data.Repositories.Interfaces;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Service.Interfaces;

namespace TeduShopingOnline.Service
{
    public class ApplicationGroupService : IApplicationGroupService
    {
        private IUnitOfWork _unitOfWork;
        private IApplicationGroupRepository _applicationGroupRepository;
        private IApplicationUserGroupRepository _applicationUserGroupRepository;

        public ApplicationGroupService(
            IUnitOfWork unitOfWork,
            IApplicationGroupRepository applicationGroupRepository,
            IApplicationUserGroupRepository applicationUserGroupRepository)
        {
            this._unitOfWork = unitOfWork;
            this._applicationGroupRepository = applicationGroupRepository;
            this._applicationUserGroupRepository = applicationUserGroupRepository;
        }

        public ApplicationGroup Add(ApplicationGroup appGroup)
        {
            if (_applicationGroupRepository.CheckContains(x => x.Name == appGroup.Name))
                throw new NameDuplicatedException(ExceptionMessage.NameDuplicatedException);
            return _applicationGroupRepository.Add(appGroup);
        }

        public ApplicationGroup Delete(int id)
        {
            var appGroup = this._applicationGroupRepository.GetSingleById(id);
            return _applicationGroupRepository.Delete(appGroup);
        }

        public IEnumerable<ApplicationGroup> GetAll()
        {
            return _applicationGroupRepository.GetAll();
        }

        public IEnumerable<ApplicationGroup> GetAll(int page, int pageSize, out int totalRow, string filter = null)
        {
            var query = _applicationGroupRepository.GetAll();
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(x => x.Name.Contains(filter));

            totalRow = query.Count();
            return query.OrderBy(x => x.Name).Skip(page * pageSize).Take(pageSize);
        }

        public ApplicationGroup GetDetail(int id)
        {
            return _applicationGroupRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ApplicationGroup appGroup)
        {
            if (_applicationGroupRepository.CheckContains(x => x.Name == appGroup.Name && x.ID != appGroup.ID))
                throw new NameDuplicatedException(ExceptionMessage.NameDuplicatedException);
            _applicationGroupRepository.Update(appGroup);
        }

        public bool AddUserToGroups(IEnumerable<ApplicationUserGroup> userGroups, string userId)
        {
            _applicationUserGroupRepository.DeleteMulti(x => x.UserId == userId);
            foreach (var userGroup in userGroups)
            {
                _applicationUserGroupRepository.Add(userGroup);
            }
            return true;
        }

        public IEnumerable<ApplicationGroup> GetListGroupByUserId(string userId)
        {
            return _applicationGroupRepository.GetListGroupByUserId(userId);
        }

        public IEnumerable<ApplicationUser> GetListUserByGroupId(int groupId)
        {
            return _applicationGroupRepository.GetListUserByGroupId(groupId);
        }
    }
}
