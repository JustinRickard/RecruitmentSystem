using System.Threading.Tasks;
using Common.Enums;
using Common.Interfaces.Helpers;
using Common.Interfaces.Repositories;

namespace Common.Services
{
    public class ServiceBase
    {
        IAuditRepository auditRepository;
        IJsonHelper jsonHelper;

        public ServiceBase (
            IAuditRepository auditRepository,
            IJsonHelper jsonHelper
        ) {
            this.auditRepository = auditRepository;
            this.jsonHelper = jsonHelper;
        }

        protected internal void Audit<T>(AuditType type, string prefix, T objectToSerialize) 
        {
            var jsonResult = jsonHelper.Serialize(objectToSerialize);
            if (jsonResult.IsSuccess) 
            {
                auditRepository.Add(type, string.Format("{0}: {1}", prefix, jsonResult.Value));
            }
            else
            {
                // log error
                // alert
            }
        }
    }
}