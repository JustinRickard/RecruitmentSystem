using Core.Interfaces;

namespace DAL.MongoDB
{
    public class RepositoryBase
    {
        protected internal IAppSettings appSettings { get; set; }

        public RepositoryBase(IAppSettings appSettings) {
            this.appSettings = appSettings;
        }

        protected internal RsMongoContext GetContext() {
            return new RsMongoContext(appSettings);
        }
    }
}