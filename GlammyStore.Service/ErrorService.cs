﻿using GlammyStore.Data.Infrastructure;
using GlammyStore.Data.Repositories;
using GlammyStore.Model.Models;

namespace GlammyStore.Service
{
    public interface IErrorService
    {
        Error Create(Error error);

        void SaveChange();
    }

    public class ErrorService : IErrorService
    {
        private IErrorRepository _errorRepository;
        private IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }

        public Error Create(Error error)
        {
            return _errorRepository.Add(error);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }
    }
}