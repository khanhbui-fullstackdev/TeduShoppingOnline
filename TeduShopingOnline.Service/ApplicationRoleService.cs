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
    public class ApplicationRoleService : IApplicationRoleService
    {
        private IUnitOfWork _unitOfWork;
        private IApplicationRoleRepository _applicationRoleRepository;
        private IApplicationRoleGroupRepository _applicationRoleGroupRepository;

        public ApplicationRoleService(
            IUnitOfWork unitOfWork,
            IApplicationRoleRepository applicationRoleRepository,
            IApplicationRoleGroupRepository applicationRoleGroupRepository)
        {
            this._unitOfWork = unitOfWork;
            this._applicationRoleRepository = applicationRoleRepository;
            this._applicationRoleGroupRepository = applicationRoleGroupRepository;
        }

        public ApplicationRole Add(ApplicationRole appRole)
        {
            if (_applicationRoleRepository.CheckContains(x => x.Description == appRole.Description))
                throw new NameDuplicatedException(ExceptionMessage.NameDuplicatedException);
            return _applicationRoleRepository.Add(appRole);
        }

        public bool AddRolesToGroup(IEnumerable<ApplicationRoleGroup> roleGroups, int groupId)
        {
            _applicationRoleGroupRepository.DeleteMulti(x => x.GroupId == groupId);
            foreach (var roleGroup in roleGroups)
            {
                _applicationRoleGroupRepository.Add(roleGroup);
            }
            return true;
        }

        public void Delete(string id)
        {
            _applicationRoleRepository.DeleteMulti(x => x.Id == id);
        }

        public IEnumerable<ApplicationRole> GetAll()
        {
            return _applicationRoleRepository.GetAll();
        }

        public IEnumerable<ApplicationRole> GetAll(int page, int pageSize, out int totalRow, string filter = null)
        {
            var query = _applicationRoleRepository.GetAll();
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(x => x.Description.Contains(filter));

            totalRow = query.Count();
            return query.OrderBy(x => x.Description).Skip(page * pageSize).Take(pageSize);
        }

        public ApplicationRole GetDetail(string id)
        {
            return _applicationRoleRepository.GetSingleByCondition(x => x.Id == id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ApplicationRole AppRole)
        {
            if (_applicationRoleRepository.CheckContains(x => x.Description == AppRole.Description && x.Id != AppRole.Id))
                throw new NameDuplicatedException(ExceptionMessage.NameDuplicatedException);
            _applicationRoleRepository.Update(AppRole);
        }

        public IEnumerable<ApplicationRole> GetListRoleByGroupId(int groupId)
        {
            return _applicationRoleRepository.GetListRoleByGroupId(groupId);
        }
    }
}
