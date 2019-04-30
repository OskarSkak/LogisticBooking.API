using System.Collections.Generic;
using AutoMapper;

namespace LogisticBooking.Documents.Resources
{
    public static class ViewModelMapper<TSource , TDestination >
    {
        public static TDestination Map(TSource source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
                cfg.CreateMap<List<TSource>, List<TDestination>>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper.Map<TSource, TDestination>(source);
        }
        
        
        public static TDestination Map(TSource source, TDestination destination)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
                cfg.CreateMap<List<TSource>, List<TDestination>>();
                

            });

            IMapper mapper = config.CreateMapper();
            
            mapper.Map<TSource, TDestination>(source, destination);
            
            

            return destination;
        }
        
        public static TDestination MapList<TOSource , TODestination>(TSource source, TDestination destination)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });

            IMapper mapper = config.CreateMapper();
            
            mapper.Map<TSource, TDestination>(source, destination);
            
            

            return destination;
        }

       
        
        public static TDestination Map(MapperConfiguration customMap, TSource source)
        {
            var config = customMap;
            config.AssertConfigurationIsValid();

            IMapper mapper = config.CreateMapper();

            return mapper.Map<TSource, TDestination>(source);
        }
        
        
        
    }
}