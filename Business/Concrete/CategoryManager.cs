using Business.Abstract;
using Business.BusinessAspetcs.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [SecuredOperation("database_administrator,admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category category)
        {
            IResult result = BusinessRules.Run(
                CheckIfCategoryNameExist(category.Name)
                );
            if (result == null)
            {
                return result;
            }
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        [SecuredOperation("database_administrator,admin")]
        public IResult Delete(int categoryId)
        {
            var dataDelete = _categoryDal.Get(p => p.Id == categoryId);

            if (dataDelete != null)
            {
                _categoryDal.Delete(dataDelete);
                return new SuccessResult(Messages.CategoryDeleted);
            }

            return new ErrorResult(Messages.CategoryNotFound);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategoriesListed);
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(p => p.Id == categoryId), Messages.SelectedCategory);
        }

        [SecuredOperation("database_administrator,admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Update(Category category)
        {
            IResult result = BusinessRules.Run(
                CheckIfCategoryNameExist(category.Name)
                );
            if (result == null)
            {
                return result;
            }
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
        private IResult CheckIfCategoryNameExist(string categoryName)
        {
            var result = _categoryDal.GetAll(p => p.Name == categoryName).Any();
            if (result)
            {
                return new ErrorResult(Messages.DataAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
