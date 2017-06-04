using GlammyStore.Data.Infrastructure;
using GlammyStore.Data.Repositories;
using GlammyStore.Model.Models;

namespace GlammyStore.Service
{
    public interface ISystemConfigService
    {
        SystemConfig GetSystemConfig(string code);
    }

    public class SystemConfigService : ISystemConfigService
    {
        private ISystemConfigRepository _systemConfigRepository;
        private IUnitOfWork _unitOfWork;

        public SystemConfigService(IUnitOfWork unitOfWork, ISystemConfigRepository systemConfigRepository)
        {
            _systemConfigRepository = systemConfigRepository;
            _unitOfWork = unitOfWork;
        }

        public SystemConfig GetSystemConfig(string code)
        {
            return _systemConfigRepository.GetSingleByCondition(x => x.Code == code);
        }
    }
}