using System.Linq.Expressions;
using AutoMapper;

namespace App.Extensions;

public static class MapperExtension
{
    public static IMappingExpression<TSource, TDestination> IgnoreDestination<TSource, TDestination>(
        this IMappingExpression<TSource, TDestination> map,
        Expression<Func<TDestination, object>> selector)
    {
        map.ForMember(selector, config => config.Ignore());
        return map;
    }
}