using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

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

        public IResult Update(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
