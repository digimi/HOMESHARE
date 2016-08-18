using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeShare.Models.Mappers
{
    public class MapperBase<TEntity> where TEntity : class
    {
        #region Mapper

        public TEntity MapToEntity()
        {
            TEntity entity = Activator.CreateInstance<TEntity>();
            try
            {
                foreach (var item in entity.GetType().GetProperties())
                {
                    item.SetValue(entity, this.GetType().GetProperty(item.Name).GetValue(this));
                }
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static TEntity MapToEntity<TViewModel>(TViewModel viewModel) where TViewModel : MapperBase<TEntity>
        {
            TEntity entity = Activator.CreateInstance<TEntity>();
            try
            {
                foreach (var item in entity.GetType().GetProperties())
                {
                    item.SetValue(entity, viewModel.GetType().GetProperty(item.Name).GetValue(viewModel));
                }
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static TViewModel MapToModel<TViewModel>(TEntity entity) where TViewModel : MapperBase<TEntity>
        {
            TViewModel viewModel = Activator.CreateInstance<TViewModel>();
            try
            {
                foreach (var item in viewModel.GetType().GetProperties())
                {
                    item.SetValue(viewModel, entity.GetType().GetProperty(item.Name).GetValue(entity));
                }
                return viewModel;
            }
            catch { return null; }
        }

        public static IEnumerable<TEntity> MapToEntity<TViewModel>(IEnumerable<TViewModel> viewModels) where TViewModel : MapperBase<TEntity>
        {
            try
            {
                List<TEntity> entities = Activator.CreateInstance<List<TEntity>>();

                foreach (var viewModel in viewModels)
                {
                    TEntity entity = Activator.CreateInstance<TEntity>();

                    foreach (var item in entity.GetType().GetProperties())
                    {
                        item.SetValue(entity, viewModel.GetType().GetProperty(item.Name).GetValue(viewModel));
                    }
                    entities.Add(entity);
                }
                return entities;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static IEnumerable<TViewModel> MapToModels<TViewModel>(IEnumerable<TEntity> entities) where TViewModel : MapperBase<TEntity>
        {
            List<TViewModel> result = Activator.CreateInstance<List<TViewModel>>();
            try
            {
                foreach (TEntity entity in entities)
                {
                    TViewModel viewmodel = Activator.CreateInstance<TViewModel>();

                    foreach (var item in viewmodel.GetType().GetProperties())
                    {
                        item.SetValue(viewmodel, entity.GetType().GetProperty(item.Name).GetValue(entity));                        
                    }
                    result.Add(viewmodel);
                }
                return result;
            }
            catch(Exception e) { return null; }
        }

        #endregion
    }
}