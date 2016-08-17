using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeShare.Models.Mappers
{
    public class MapperBase<TEntity> where TEntity : class
    {
        #region Mapper

        public TEntity MapToEntity(TEntity entity)
        {
            try
            {
                foreach (var item in entity.GetType().GetProperties(System.Reflection.BindingFlags.GetProperty))
                {
                    item.SetValue(item, this.GetType().GetProperty(item.Name).GetValue(this));
                }
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TViewModel MapToModel<TViewModel>(TEntity entity) where TViewModel : MapperBase<TEntity>
        {
            TViewModel result = Activator.CreateInstance<TViewModel>();
            try
            {
                foreach (var item in this.GetType().GetProperties(System.Reflection.BindingFlags.GetProperty))
                {
                    item.SetValue(item, entity.GetType().GetProperty(item.Name).GetValue(entity));
                }
                return result;
            }
            catch { return null; }
        }

        public IEnumerable<TEntity> MapToEntity<TViewModel>(IEnumerable<TViewModel> viewModels) where TViewModel : MapperBase<TEntity>
        {
            try
            {
                List<TEntity> entities = Activator.CreateInstance<List<TEntity>>();

                foreach (var viewModel in viewModels)
                {
                    TEntity entity = Activator.CreateInstance<TEntity>();

                    foreach (var item in viewModel.GetType().GetProperties(System.Reflection.BindingFlags.GetProperty))
                    {
                        item.SetValue(item, entity.GetType().GetProperty(item.Name).GetValue(viewModel));
                    }
                }
                return entities;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<TViewModel> MapToModels<TViewModel>(IEnumerable<TEntity> entities) where TViewModel : MapperBase<TEntity>
        {
            List<TViewModel> result = Activator.CreateInstance<List<TViewModel>>();
            try
            {
                foreach (TEntity entity in entities)
                {
                    TViewModel viewmodel = Activator.CreateInstance<TViewModel>();

                    foreach (var item in viewmodel.GetType().GetProperties(System.Reflection.BindingFlags.GetProperty))
                    {
                        item.SetValue(item, entity.GetType().GetProperty(item.Name).GetValue(entity));
                    }
                    result.Add(viewmodel);
                }
                return result;
            }
            catch { return null; }
        }

        #endregion
    }
}