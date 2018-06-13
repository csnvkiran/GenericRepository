using System;
using System.Collections.Generic;
using System.Text;
using GR.Service.Interface;
using GR.Model;
using GR.Model.Interface;
using GR.Repository.Interface;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;
using GR.Service.Resource;
using System.Reflection;
using System.Linq;
using AutoMapper;
using FluentValidation;

namespace GR.Service
{
    public abstract class EntityService<TEntity, TModel, SModel> :
        IEntityService<TEntity>,
        IEntityServiceAED<TEntity, SModel>,
        IModelService<TEntity>
        where TEntity : Entity
        where TModel : class
        where SModel : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityReadRepository<TEntity> _readRepository;
        private readonly IEntityRepository<TEntity> _repository;

        private readonly ILogger _logger;
        private readonly IStringLocalizer _localizer;

        private readonly IValidator<SModel> _validator;

        public EntityService(IUnitOfWork unitOfWork, IEntityReadRepository<TEntity> readRepository, IEntityRepository<TEntity> repository, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory, IValidator<SModel> validator)
        {
            _unitOfWork = unitOfWork;
            _readRepository = readRepository;
            _repository = repository;
            _logger = loggerFactory.CreateLogger<EntityService<TEntity, TModel, SModel>>();
            _localizer = localizerFactory.Create(typeof(ServiceResource));
            _validator = validator;
        }

        public IResponse GetAll(string requestId, params Expression<Func<TEntity, object>>[] includes)
        {

            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(ServiceResource.ServiceStart, m.Name, requestId);
            try
            {
                var result = new Response(requestId) { Data = _readRepository.GetAll(requestId, includes) };
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

        public IResponse GetBy(string requestId, Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {

            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(ServiceResource.ServiceStart, m.Name, requestId);

            try
            {
                var result = new Response(requestId) { Data = _readRepository.GetBy(requestId, filter, includes) };
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

        public IResponse GetSingleBy(string requestId, Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {

            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(ServiceResource.ServiceStart, m.Name, requestId);

            try
            {
                var result = new Response(requestId) { Data = _readRepository.GetSingleBy(requestId, filter, includes) };
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


        public IResponse GetAllModel(string requestId, params Expression<Func<TEntity, object>>[] includes)
        {

            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(ServiceResource.ServiceStart, m.Name, requestId);
            try
            {
                var data = _readRepository.GetAll(requestId, includes).AsEnumerable().Select(role => Mapper.Map<TEntity, TModel>(role)).ToList();
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

        public IResponse GetByModel(string requestId, Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(ServiceResource.ServiceStart, m.Name, requestId);

            try
            {
                var data = _readRepository.GetBy(requestId, filter, includes).AsEnumerable().Select(role => Mapper.Map<TEntity, TModel>(role)).ToList();
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

        #region Add - Edit - Delete

        public IResponse Add(string requestId, SModel SaveModel)
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
                _repository.Add(requestId, entity);
                _unitOfWork.Save(requestId);

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

        public IResponse AddBulk(string requestId, SModel SaveModel, Boolean doCommit)
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
                _repository.Add(requestId, entity);

                if (doCommit == true)
                    _unitOfWork.Save(requestId);

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

        public IResponse Edit(string requestId, SModel SaveModel)
        {

            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(ServiceResource.ServiceStart, m.Name, requestId);


            if (SaveModel == null) throw new ArgumentNullException("SaveModel");


            try
            {
                TEntity entity = Mapper.Map<SModel, TEntity>(SaveModel);

                _repository.Edit(requestId, entity);
                _unitOfWork.Save(requestId);

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

        public IResponse Delete(string requestId, TEntity entity)
        {

            MethodBase m = MethodBase.GetCurrentMethod();
            _logger.LogInformation(ServiceResource.ServiceStart, m.Name, requestId);

            if (entity == null) throw new ArgumentNullException("SaveModel");

            try
            {
                //TEntity entity = Mapper.Map<SModel, TEntity>(SaveModel);
                _repository.Delete(requestId, entity);
                _unitOfWork.Save(requestId);
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
       
        #endregion
    }
}
