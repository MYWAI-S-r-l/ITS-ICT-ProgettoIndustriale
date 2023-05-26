using System;
using System.Collections.Generic;
using AutoMapper;

namespace ProgettoIndustriale.Type;

public static class MyMapper<TSource, TDestination>
{
    public static TDestination Map(TSource obj, Dictionary<System.Type,List<string>> ignores = null)
    {
        MapperConfiguration config = new MapperConfiguration(CreateEnrichedMapper(ignores));
        IMapper mapper = config.CreateMapper();

        TDestination ret = mapper.Map<TDestination>(obj);

        return ret;
    }

    public static TDestination MapToExisting(TSource obj, TDestination existingObj, Dictionary<System.Type,List<string>> ignores = null)
    {
        MapperConfiguration config = new MapperConfiguration(CreateEnrichedMapper(ignores));
        IMapper mapper = config.CreateMapper();

        mapper.Map(obj, existingObj);

        return existingObj;
    }

    public static IEnumerable<TDestination> MapEnumerable(IEnumerable<TSource> objEnumerable, Dictionary<System.Type,List<string>> ignores = null)
    {
        MapperConfiguration config = new MapperConfiguration(CreateEnrichedMapper(ignores));
        IMapper mapper = config.CreateMapper();

        IEnumerable<TDestination> ret = mapper.Map<IEnumerable<TDestination>>(objEnumerable);

        return ret;
    }
    public static List<TDestination> MapList(List<TSource> objEnumerable)
    {
        var config = new MapperConfiguration(CreateEnrichedMapper());
        var mapper = config.CreateMapper();

        return mapper.Map<List<TDestination>>(objEnumerable);
    }
    
    private static Action<IMapperConfigurationExpression> CreateEnrichedMapper(Dictionary<System.Type, List<string>> ignores = null)
        {
            return cfg =>
            {
                //AddMapping<Domain.Ente, Dto.Ente>(cfg, ignores);
                AddMapping<Domain.Provincia, Dto.Provincia>(cfg, ignores);
                AddMapping<Domain.TernaToken, Dto.TernaToken>(cfg, ignores);
                AddMapping<Dto.TernaToken, Domain.TernaToken>(cfg, ignores);
            };
        }

    private static void ApplyIgnores<TS, TD>(IMemberConfigurationExpression<TS, TD, object> m, Dictionary<System.Type, List<string>> ignores)
        {
            foreach (var (key, value) in ignores)
            {
                if (key != typeof(TS))
                    continue;

                var name = m.DestinationMember.Name;
                if (value.Contains(name))
                {
                    m.Ignore();
                }
            }
        }

        private static IMappingExpression<TS, TD> AddMapping<TS, TD>(IProfileExpression config, Dictionary<System.Type, List<string>> ignores)
        {
            var mapExpr = config.CreateMap<TS, TD>();
            if (ignores == null)
                return mapExpr;

            mapExpr.ForAllMembers(m =>
            {
                ApplyIgnores(m, ignores);
            });

            return mapExpr;
        }
}
