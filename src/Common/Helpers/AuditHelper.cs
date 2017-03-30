using System;
using System.Threading.Tasks;
using Common.Enums;
using Common.Interfaces.Helpers;
using Common.Interfaces.Repositories;

namespace Common.Helpers
{
    public class AuditHelper : IAuditHelper
    {
        private IJsonHelper jsonHelper;
        private IAuditRepository auditRepository;
        public AuditHelper(
            IJsonHelper jsonHelper,
            IAuditRepository auditRepository)
        {
            this.jsonHelper = jsonHelper;
            this.auditRepository = auditRepository;

        }

        public async Task Audit(AuditType type, string message)
        {
            await auditRepository.Add(type, message);
        }
        public async Task Audit<T>(AuditType type, string prefix, T objectToSerialize) 
        {
            await Audit(type, prefix, objectToSerialize, new {});
        }

        public async Task Audit<T1,T2>(AuditType type, string prefix, T1 objectToSerialize, T2 parameters)
        {
            var jsonResultObject = jsonHelper.Serialize(objectToSerialize);
            var jsonResultParameters = jsonHelper.Serialize(parameters);
            if (jsonResultObject.IsSuccess && jsonResultParameters.IsSuccess) 
            {
                await auditRepository.Add(type, string.Format("{0}: {1}, {2}: {3}", prefix, jsonResultObject.Value, "Parameters", jsonResultParameters.Value));
            }
            else
            {
                // throw new Exception("Failed to add audit for service.");
                // log error
                // alert
            }
        }
        
    }
}