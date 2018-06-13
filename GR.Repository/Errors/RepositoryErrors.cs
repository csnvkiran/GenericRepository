using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GR.Repository.Interface;

namespace GR.Repository
{


    public class EntitySuccessResult : IEntityResult
    {

        private EntitySuccessResult(int effectedRows)
        {

            ResultStatus = true;
            EffectedRows = effectedRows;
        }

        public bool ResultStatus { get; }

        public int EffectedRows { get; }

        public static EntitySuccessResult Success(int RowsEffected) => new EntitySuccessResult(RowsEffected);

        //public override string ToString()
        //{
        //    return Succeeded
        //        ? "Succeeded"
        //        : $"Failed :[{string.Join(",", Errors.Select(x => x.Code).ToList())}]";
        //}
    }


    public class EntityErrorResult : IEntityResult
    {
        private EntityErrorResult(params EntityError[] errors)
        {
            Errors = errors;
        }

        public IEnumerable<EntityError> Errors { get; }

        public static EntityErrorResult Failure(params EntityError[] errors) => new EntityErrorResult(errors);

        //public override string ToString()
        //{
        //    return Succeeded
        //        ? "Succeeded"
        //        : $"Failed :[{string.Join(",", Errors.Select(x => x.Code).ToList())}]";
        //}

    }

   


    public class EntityError
    {
        public static readonly EntityError ConcurrencyFailure = new EntityError(10001, "ConcurrencyFailure");
        public static readonly EntityError DbUpdateFailure = new EntityError(10002, "DbUpdateFailure");
        public static readonly EntityError DbReadFailure = new EntityError(10003, "DbReadFailure");
        public static readonly EntityError UnknownFailure = new EntityError(10004, "UnknownFailure");



        public EntityError(int code, string error)
        {
            Code = code;
            Error = error;
        }

        public int Code { get; }
        public string Error { get; }
    }


}
