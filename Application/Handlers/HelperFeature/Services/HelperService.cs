using Application.DTO;
using Dapper;
using System.Data;

namespace Application.Handlers.LookupsFeature.Services
{
    public class HelperService : IHelperService
    {
        private readonly ApplicationDbContext _applicationDbContext;


        public HelperService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }
        public async Task<DropDownsDTO> FillDropDowns(List<int> PagesID)
        {
            DropDownsDTO dropdownsData = new DropDownsDTO();
            IDbConnection DbConnection = _applicationDbContext.Database.GetDbConnection();
            DbConnection.Open();
            using (var transaction = DbConnection.BeginTransaction())
            {
                try
                {
                    var lookUps = new List<Task<IReadOnlyCollection<LookUpsDTO>>>();

                    if (PagesID.Contains((int)enumPagesID.JobClasses))
                    {
                        lookUps.Add(Task.Run(async () => dropdownsData.JobClasses = (await DbConnection
                        .QueryAsync<LookUpsDTO>("select JOB_CLS_CODE ID,JOB_CLS_CODE Code,JOB_CLS_DESC LatinName,JOB_CLS_DESC ArabicName from CDE_JOB_CLASSES", null, transaction)).AsList()));
                    }


                    if (PagesID.Contains((int)enumPagesID.Jobs))
                    {
                        lookUps.Add(Task.Run(async () => dropdownsData.Jobs = (await DbConnection.QueryAsync<LookUpsDTO>("select  JOB_CODE ID, JOB_CODE  Code , JOB_CLS_CODE ParentID,  JOB_DESC LatinName, JOB_DESC ArabicName from CDE_JOBS ", null, transaction)).AsList()));

                    }


                    if (PagesID.Contains((int)enumPagesID.Grades))
                    {
                        lookUps.Add(Task.Run(async () => dropdownsData.Grades = (await DbConnection.QueryAsync<LookUpsDTO>("select  GRADE_CODE ID, GRADE_CODE  Code ,  GRADE_DESC LatinName, GRADE_DESC ArabicName from CDE_GRADES", null, transaction)).AsList()));
                    }

                    if (PagesID.Contains((int)enumPagesID.Qualifications))
                    {
                        lookUps.Add(Task.Run(async () => dropdownsData.Qualifications = (await DbConnection.QueryAsync<LookUpsDTO>(" select QLF_CODE  ID,  QLF_CODE  Code ,QLF_TYP ParentID, QLF_DESC LatinName, QLF_DESC ArabicName  from CDE_QUALIFICATIONS", null, transaction)).AsList()));
                    }
                    if (PagesID.Contains((int)enumPagesID.QualificationTypes))
                    {
                        lookUps.Add(Task.Run(async () => dropdownsData.QualificationTypes = (await DbConnection.QueryAsync<LookUpsDTO>("select  QLF_TYP ID,QLF_TYP Code,QUAL_ENT_TYPE ParentID, QLF_TYP_DESC LatinName, QLF_TYP_DESC ArabicName  from CDE_QLF_TYPES", null, transaction)).AsList()));
                    }

                    if (PagesID.Contains((int)enumPagesID.QualificationEntities))
                    {
                        lookUps.Add(Task.Run(async () => dropdownsData.QualificationEntities = (await DbConnection.QueryAsync<LookUpsDTO>("select QUAL_ENT_CODE  ID,QUAL_ENT_CODE Code,QUAL_ENT_TYPE ParentID, QUAL_ENT_DESC LatinName, QUAL_ENT_DESC ArabicName  from CDE_QUALIFICATION_ENT", null, transaction)).AsList()));
                    }
                    await Task.WhenAll(lookUps.ToArray());
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    dropdownsData = new DropDownsDTO();

                    return dropdownsData;
                }
                finally
                {

                    DbConnection.Close();
                }
                return dropdownsData;
            }

        }


    }
}
