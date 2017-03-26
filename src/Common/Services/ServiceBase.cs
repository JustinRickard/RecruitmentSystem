using System;
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

        protected internal async Task Audit<T>(AuditType type, string prefix, T objectToSerialize) 
        {
            await SaveAudit(type, prefix, objectToSerialize, new {});
        }

        protected internal async Task Audit<T1,T2>(AuditType type, string prefix, T1 objectToSerialize, T2 parameters)
        {
            await SaveAudit(type, prefix, objectToSerialize, parameters);
        }

        private async Task SaveAudit<T1,T2>(AuditType type, string prefix, T1 objectToSerialize, T2 parameters)
        {
            var jsonResultObject = jsonHelper.Serialize(objectToSerialize);
            var jsonResultParameters = jsonHelper.Serialize(parameters);
            if (jsonResultObject.IsSuccess && jsonResultParameters.IsSuccess) 
            {
                await auditRepository.Add(type, string.Format("{0}: {1}, {2}: {3}", prefix, jsonResultObject.Value, "Parameters", jsonResultParameters.Value));
            }
            else
            {
                throw new Exception("Failed to add audit for service.");
                // log error
                // alert
            }
        }
    }
}