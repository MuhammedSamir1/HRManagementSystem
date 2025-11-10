using HRManagementSystem.Common.Views;
using MapperConfiguration = AutoMapper.IConfigurationProvider;
namespace HRManagementSystem.Common.Extensions
{
    public static class PagedListExtensions
    {

        public static PagedList<TDestination> MapTo<TSource, TDestination>(
            this PagedList<TSource> source,
            MapperConfiguration configuration)
            where TSource : class
            where TDestination : class
        {
            // إنشاء الـ Mapper instance (يجب أن يتم تمرير ConfigurationProvider)
            var mapper = new Mapper(configuration);

            // تحويل كل عنصر في القائمة باستخدام الـ AutoMapper
            var mappedItems = mapper.Map<List<TDestination>>(source.Items);

            // إرجاع PagedList جديد يحتوي على الـ ViewModels
            return new PagedList<TDestination>
            {
                CurrentPage = source.CurrentPage,
                TotalPages = source.TotalPages,
                PageSize = source.PageSize,
                TotalCount = source.TotalCount,
                Items = mappedItems
            };
        }
    }
}
