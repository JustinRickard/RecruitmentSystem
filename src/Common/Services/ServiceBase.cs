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
            SaveAudit(type, prefix, objectToSerialize, new {});

            /*
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
             */
        }

        protected internal void Audit<T1,T2>(AuditType type, string prefix, T1 objectToSerialize, T2 parameters)
        {
            SaveAudit(type, prefix, objectToSerialize, parameters);
        }

        private void SaveAudit<T1,T2>(AuditType type, string prefix, T1 objectToSerialize, T2 parameters)
        {
            var jsonResultObject = jsonHelper.Serialize(objectToSerialize);
            var jsonResultParameters = jsonHelper.Serialize(parameters);
            if (jsonResultObject.IsSuccess && jsonResultParameters.IsSuccess) 
            {
                auditRepository.Add(type, string.Format("{0}: {1}, {2}: {3}", prefix, jsonResultObject.Value, "Parameters", jsonResultParameters.Value));
            }
            else
            {
                // log error
                // alert
            }
        }
    }
}