using application.DTOs.Objects.Category;
using application.DTOs.Objects.Homework;
using application.Models;
using AutoMapper;

namespace application.DataAccess
{
    public abstract class Automapper
    {
        private static bool _initMapper = true;
        public static IMapper? Mapper;
        
        public static void Start()
        {
            if (_initMapper)
            {
                MapperConfiguration configuration = new MapperConfiguration(cfg =>
                {

                    cfg.CreateMap<Category, CategoryDto>().MaxDepth(2);
                    cfg.CreateMap<CategoryDto, Category>().MaxDepth(2);
                    
                    cfg.CreateMap<Homework, HomeworkDto>().MaxDepth(2);
                    cfg.CreateMap<HomeworkDto, Homework>().MaxDepth(2);
                    cfg.CreateMap<Homework, HomeworkWithCategory>()
                        .ForMember(dest => dest.category, opt => opt.MapFrom(src => src.Category));
                });
                
                Mapper = configuration.CreateMapper();
                _initMapper = false;
            }
        } 
    }
}
