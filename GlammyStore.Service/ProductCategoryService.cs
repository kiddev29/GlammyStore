using System;
using System.Collections.Generic;
using GlammyStore.Common.Services.Int32;
using GlammyStore.Data.Infrastructure;
using GlammyStore.Data.Repositories;
using GlammyStore.Data.Models;
using System.Linq;

namespace GlammyStore.Service
{
    public interface IProductCategoryService : ICrudService<ProductCategory>, IGetDataService<ProductCategory>
    {
        IEnumerable<ProductCategory> GetTopParents(int Limit = 6);

        IEnumerable<ProductCategory> GetAllByParentID(int parentID);

        void IsDeleted(int id);
    }

    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public ProductCategory Add(ProductCategory productCategory)
        {
            productCategory.CreatedDate = DateTime.Now;
            return _productCategoryRepository.Add(productCategory);
        }

        public void Update(ProductCategory productCategory)
        {
            productCategory.UpdatedDate = DateTime.Now;
            _productCategoryRepository.Update(productCategory);
        }

        public void Delete(int id)
        {
            _productCategoryRepository.Delete(id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetMulti(x => x.IsDeleted == false).OrderBy(x => x.DisplayOrder);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<ProductCategory> GetAllByParentID(int parentID)
        {
            return _productCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentID).OrderBy(x => x.DisplayOrder);
        }

        public ProductCategory FindById(int id)
        {
            return _productCategoryRepository.GetSingleById(id);
        }

        public IEnumerable<ProductCategory> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _productCategoryRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword) && x.IsDeleted == false).OrderBy(x => x.DisplayOrder);
            else
                return _productCategoryRepository.GetMulti(x => x.IsDeleted == false).OrderBy(x => x.DisplayOrder);
        }

        public void IsDeleted(int id)
        {
            var category = FindById(id);
            category.IsDeleted = true;
            SaveChanges();
        }

        public IEnumerable<ProductCategory> GetTopParents(int Limit = 6)
        {
            return _productCategoryRepository.GetMulti(x => x.Status && x.ParentID == null).OrderBy(x => x.DisplayOrder).Take(Limit);
        }
    }
}