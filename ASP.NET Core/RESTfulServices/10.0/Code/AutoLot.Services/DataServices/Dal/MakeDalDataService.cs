namespace AutoLot.Services.DataServices.Dal;

public class MakeDalDataService(
    IAppLogging appLoggingInstance,
    IMakeRepo makeRepoInstance)
    : DalDataServiceBase<Make>(appLoggingInstance, makeRepoInstance), IMakeDataService
{
}