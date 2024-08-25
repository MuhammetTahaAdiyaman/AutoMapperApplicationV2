using AutoMapper;
using System;
using System.Collections.Generic;

namespace AutoMapperApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Not: biz mappleme işleminde prop isimleri ve tipleri aynı olsun demiştik peki farklı olursa ne olacak ?

            //var configuration = new MapperConfiguration(opt =>
            //{
            //    opt.CreateMap<Product, ProductListDto>().ForMember(x => x.Name, product => product.MapFrom(x => x.ProductName));
            //});

            //var mapper = configuration.CreateMapper();

            //mapper.Map<ProductListDto>(new Product
            //{
            //    Id = 1,
            //    ProductName = "Telefon",
            //    Stock = 10
            //});

            //peki biz biz Product'tan productlistdto mapliyorduk tam tersi içinde şu şekilde yapabiliriz.
            //var configuration = new MapperConfiguration(opt =>
            //{
            //    opt.CreateMap<Product, ProductListDto>().ForMember(x => x.Name, product => product.MapFrom(x => x.ProductName)).ReverseMap();
            //});

            //var mapper = configuration.CreateMapper();
            //var productList = new List<Product>{
            //    new Product(){Id=1,ProductName="Tel1",Stock=20},
            //    new Product(){Id=1,ProductName="Tel2",Stock=20},


            //};
            //var dto = mapper.Map<ProductListDto>(productList);

            //mapper.Map<Product>(dto);


            //bir de profile classı oluşturup bunu constructor içinde belirtip çağıradabiliriz.
            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new ProductProfile());

            });
            var mapper = configuration.CreateMapper();
            var productList = new List<Product>{
                new Product(){Id=1,ProductName="Tel1",Stock=20},
                new Product(){Id=1,ProductName="Tel2",Stock=20},


            };
            var dto = mapper.Map<ProductListDto>(productList);

            mapper.Map<Product>(dto);
        }
    }

    public class ProductProfile : Profile
    {
            public ProductProfile()
            {
                CreateMap<Product, ProductListDto>().ForMember(x => x.Name, product => product.MapFrom(x => x.ProductName)).ReverseMap();
            }
        }

    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
    }

    public class ProductListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
    }
}
