using System;
using System.Collections.Generic;
using System.Text;
using GR.Service.Interface;
using GR.Model;
using GR.Repository.Interface;
using System.Threading.Tasks;
using System.Threading;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;
using GR.Service.Resource;
using System.Linq;
using AutoMapper;
using System.Reflection;
using FluentValidation;

namespace GR.Service
{

    public abstract class EntityServiceAsync<TEntity, VModel, SModel> :
        IEntityServiceAsync<TEntity>,
        IEntityServiceCUDAsync<TEntity, SModel>,
        IModelServiceAsync<TEntity>
        where TEntity : Entity
        where VModel : class
        where SModel : class
    {
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly IEntityReadRepositoryAsync<TEntity> _readRepository;
        private readonly IEntityRepositoryAsync<TEntity> _repository;

        private readonly ILogger _logger;
        private readonly IStringLocalizer _localizer;

        private readonly IValidator<SModel> _validator;
        public EntityServiceAsync(IUnitOfWorkAsync unitOfWork, IEntityReadRepositoryAsync<TEntity> readRepository, IEntityRepositoryAsync<TEntity> repository, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory, IValidator<SModel> validator)
        {
            _unitOfWork = unitOfWork;
            _readRepository = readRepository;
            _repository = repository;
            _logger = loggerFactory.CreateLogger<EntityServiceAsync<TEntity, VModel, SModel>>();
            _localizer = localizerFactory.Create(typeof(ServiceResource));
            _validator = validator;
        }
        #region Read

        public async Task<IResponse> GetAllAsync(string requestId, CancellationToken cancellationToken = default(CancellationToken), params Expression<Func<TEntity, object>>[] includes)
        {


            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(ServiceResource.ServiceStart, m.Name, requestId);
            try
            {
                var result = new Response(requestId) { Data = await _readRepository.GetAllAsync(requestId, cancellationToken, includes) };
                _logger.LogInformation(ServiceResource.ServiceEnd, m.Name, requestId);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                  new EventId(ServiceError.DataReadServiceError.Code, ServiceError.DataReadServiceError.Error), ex,
                  _localizer[ServiceResource.ServiceError], m.Name, requestId);

                // return new FailureResponse(requestId, new[] { error });
                // return new Response(requestId) { Data = null };
                return new ServiceErrorReponse(requestId) { Message = ex.Message, ServiceErrors = new[] { ServiceError.DataReadServiceError } };
            }

        }

        public async Task<IResponse> GetByAsync(string requestId, Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default(CancellationToken), params Expression<Func<TEntity, object>>[] includes)
        {

            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(ServiceResource.ServiceStart, m.Name, requestId);

            try
            {
                var result = new Response(requestId) { Data = await _readRepository.GetByAsync(requestId, filter, cancellationToken, includes) };
                _logger.LogInformation(ServiceResource.ServiceEnd, m.Name, requestId);
                return result;
            }
            catch (Exception ex)
            {

                _logger.LogError(
                  new EventId(ServiceError.DataReadServiceError.Code, ServiceError.DataReadServiceError.Error), ex,
                  _localizer[ServiceResource.ServiceError], m.Name, requestId);

                // return new FailureResponse(requestId, new[] { error });
                return new ServiceErrorReponse(requestId) { Message = ex.Message, ServiceErrors = new[] { ServiceError.DataReadServiceError } };
            }

        }

        public async Task<IResponse> GetSingleByAsync(string requestId, Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default(CancellationToken), params Expression<Func<TEntity, object>>[] includes)
        {


            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(ServiceResource.ServiceStart, m.Name, requestId);

            try
            {
                var result = new Response(requestId) { Data = await _readRepository.GetSingleByAsync(requestId, filter, cancellationToken, includes) };
                _logger.LogInformation(ServiceResource.ServiceEnd, m.Name, requestId);
                return result;
            }
            catch (Exception ex)
            {

                _logger.LogError(
                  new EventId(ServiceError.DataReadServiceError.Code, ServiceError.DataReadServiceError.Error), ex,
                  _localizer[ServiceResource.ServiceError], m.Name, requestId);

                // return new FailureResponse(requestId, new[] { error });
                return new ServiceErrorReponse(requestId) { Message = ex.Message, ServiceErrors = new[] { ServiceError.DataReadServiceError } };
            }

           
        }


        public async Task<IResponse> GetAllModelAsync(string requestId, CancellationToken cancellationToken = default(CancellationToken), params Expression<Func<TEntity, object>>[] includes)
        {



            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(ServiceResource.ServiceStart, m.Name, requestId);
            try
            {

                IEnumerable<TEntity> tresult = await _readRepository.GetAllAsync(requestId, cancellationToken, includes).ConfigureAwait(false);
                var data = tresult.AsEnumerable().Select(role => Mapper.Map<TEntity, VModel>(role)).ToList();
                if (data == null || data.Count() == 0)
                {

                    return new ServiceErrorReponse(requestId) { Message = "No Data found" };
                }

                var result = new Response(requestId) { Data = data };
                _logger.LogInformation(ServiceResource.ServiceEnd, m.Name, requestId);
                return result;
            }
            catch (Exception ex)
            {

                _logger.LogError(
                  new EventId(ServiceError.DataReadServiceError.Code, ServiceError.DataReadServiceError.Error), ex,
                  _localizer[ServiceResource.ServiceError], m.Name, requestId);

                // return new FailureResponse(requestId, new[] { error });
                //
                //return new Response(requestId) { Data = null };
                return new ServiceErrorReponse(requestId) { Message = ex.Message, ServiceErrors = new[] { ServiceError.DataReadServiceError } };
            }

                        
        }

        public async Task<IResponse> GetByModelAsync(string requestId, Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default(CancellationToken), params Expression<Func<TEntity, object>>[] includes)
        {


            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(ServiceResource.ServiceStart, m.Name, requestId);

            try
            {
                IEnumerable<TEntity> tresult = await _readRepository.GetByAsync(requestId, filter, cancellationToken, includes).ConfigureAwait(false);
                var data = tresult.AsEnumerable().Select(role => Mapper.Map<TEntity, VModel>(role)).ToList();
                //if (data == null || data.Count() == 0)
                //{

                //    return new ServiceErrorReponse(requestId) { Message = "No Data found" };
                //}

                var result = new Response(requestId) { Data = data };
                _logger.LogInformation(ServiceResource.ServiceEnd, m.Name, requestId);

                return result;
            }
            catch (Exception ex)
            {

                _logger.LogError(
                 new EventId(ServiceError.DataReadServiceError.Code, ServiceError.DataReadServiceError.Error), ex,
                 _localizer[ServiceResource.ServiceError], m.Name, requestId);

                return new ServiceErrorReponse(requestId) { Message = "", ServiceErrors = new[] { ServiceError.DataReadServiceError } };
            }
            
         
        }

        #endregion

        #region Add - Edit - Delete 


        public async Task<IResponse> AddAsync(string requestId, SModel SaveModel, CancellationToken cancellationToken = default(CancellationToken))
        {

            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(ServiceResource.ServiceStart, m.Name, requestId);

            //Check for NUll
            if (SaveModel == null)
            {
                throw new ArgumentNullException("SaveModel");
            }

            //Do Validator
            var validationResult = _validator.Validate(SaveModel);
            if (!validationResult.IsValid)
            {

                _logger.LogInformation(ServiceResource.ServiceValidationError, m.Name, requestId);

                return new ValidationErrorsReponse(requestId, "Save Model Validation Failure.",
                    validationResult.Errors.Select(e => new ValidationError(e.PropertyName, e.ErrorMessage)).ToList());
            }


            try
            {
                TEntity entity = Mapper.Map<SModel, TEntity>(SaveModel);
                await _repository.AddAsync(requestId, entity);
                await _unitOfWork.SaveAsync(requestId, cancellationToken);

                _logger.LogInformation(ServiceResource.ServiceEnd, m.Name, requestId);
                return new SuccessResponse(requestId) { Success = true };


            }
            catch (Exception ex)
            {
                _logger.LogError(
                  new EventId(ServiceError.DataUpdateServiceError.Code, ServiceError.DataUpdateServiceError.Error), ex,
                  _localizer[ServiceResource.ServiceError], m.Name, requestId);

                return new ServiceErrorReponse(requestId) { Message = ex.Message, ServiceErrors = new[] { ServiceError.DataUpdateServiceError } };
            }


         
        }


        public async Task<IResponse> AddBulkAsync(string requestId, SModel SaveModel, Boolean doCommit, CancellationToken cancellationToken = default(CancellationToken))
        {



            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(ServiceResource.ServiceStart, m.Name, requestId);


            if (SaveModel == null)
            {
                throw new ArgumentNullException("SaveModel");
            }

            try
            {
                TEntity entity = Mapper.Map<SModel, TEntity>(SaveModel);
                await _repository.AddAsync(requestId, entity);
                if (doCommit == true)
                { await _unitOfWork.SaveAsync(requestId, cancellationToken); }

                _logger.LogInformation(ServiceResource.ServiceEnd, m.Name, requestId);
                return new SuccessResponse(requestId) { Success = true };

            }
            catch (Exception ex)
            {

                _logger.LogError(
                 new EventId(ServiceError.DataUpdateServiceError.Code, ServiceError.DataUpdateServiceError.Error), ex,
                 _localizer[ServiceResource.ServiceError], m.Name, requestId);

                return new ServiceErrorReponse(requestId) { Message = ex.Message, ServiceErrors = new[] { ServiceError.DataUpdateServiceError } };

            }




        }

        public async Task<IResponse> EditAsync(string requestId, SModel SaveModel, CancellationToken cancellationToken = default(CancellationToken))
        {



            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(ServiceResource.ServiceStart, m.Name, requestId);


            if (SaveModel == null) throw new ArgumentNullException("SaveModel");


            try
            {
                TEntity entity = Mapper.Map<SModel, TEntity>(SaveModel);

                await _repository.EditAsync(requestId, entity);
                await _unitOfWork.SaveAsync(requestId, cancellationToken);

                _logger.LogInformation(ServiceResource.ServiceEnd, m.Name, requestId);
                return new SuccessResponse(requestId) { Success = true };
            }
            catch (Exception ex)
            {

                _logger.LogError(
                new EventId(ServiceError.DataUpdateServiceError.Code, ServiceError.DataUpdateServiceError.Error), ex,
                _localizer[ServiceResource.ServiceError], m.Name, requestId);

                return new ServiceErrorReponse(requestId) { Message = ex.Message, ServiceErrors = new[] { ServiceError.DataUpdateServiceError } };
            }

        }

        public async Task<IResponse> DeleteAsync(string requestId, Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            //if (entity == null) throw new ArgumentNullException("entity");
            TEntity entity = await _readRepository.GetSingleByAsync(requestId, filter, cancellationToken); //Mapper.Map<SModel, TEntity>(SaveModel);
            await _repository.DeleteAsync(requestId, entity);
            await _unitOfWork.SaveAsync(requestId, cancellationToken);

            return new SuccessResponse(requestId) { Success = true };
        }


        #endregion



    }
}
