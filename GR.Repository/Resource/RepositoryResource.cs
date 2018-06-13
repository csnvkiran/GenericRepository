
namespace GR.Repository.Resource
{
    public static class RepositoryResource
    {

        public const string RepositoryDisposed = "Repository Disposed";
        public const string StartReadData = "Start Read Data Method, Request Id - {0}.";
        public const string ReadDataSuccess = "Data Read Successfull,  Request Id - {0}.";
        public const string ReadDataSuccessWithCount = "Data Read Successfully, Record Count {0}, Request Id - {1}. ";
        public const string ReadDateFailure = "Failed to Read Data, Request Id - {0}.";

        public const string AddDataStart = "Start Add Data Method, Request Id - {0}.";
        public const string AddDataFailure = "Failed to Add Data, Request Id - {0}.";
        public const string AddDataSuccess = "Data Add Successfull, Request Id - {0}.";

        public const string EditDataStart = "Start Edit Data Method, Request Id - {0}.";
        public const string EditDataFailure = "Failed to Edit Data, Request Id - {0}.";
        public const string EditDataSuccess = "Data Edit Successfull, Request Id - {0}.";

        public const string DeleteDataStart = "Start Delete Data Method, Request Id - {0}.";
        public const string DeleteDataFailure = "Failed to Delete Data, Request Id - {0}.";
        public const string DeleteDataSuccess = "Data Delete Successfull, Request Id - {0}.";

        public const string StartSaveDate = "Start Saving Data, Request Id - {0}.";
        public const string SaveDataSuccess = "Data Saved Successfully, Request Id - {0}.";
        public const string SaveDataFailure = "Failed to Save Data, Request Id - {0}.";
        public const string ConcurrencyFailure = "Data Concurrency failed to Save Data, Request Id - {0}.";
        public const string SaveChangesFailure = "Failed to Save Data,  Request Id - {0}.";
    }
}
