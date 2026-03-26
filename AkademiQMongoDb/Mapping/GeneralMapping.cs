using AkademiQMongoDb.Dtos.AboutSection1;
using AkademiQMongoDb.Dtos.AboutSection2;
using AkademiQMongoDb.Dtos.FeatureDto;
using AkademiQMongoDb.Dtos.OrderDto;
using AkademiQMongoDb.Dtos.ProductDto;
using AkademiQMongoDb.Dtos.SSSDto;
using AkademiQMongoDb.Dtos.StoryVideoDto;
using AkademiQMongoDb.Dtos.SubscribeDto;
using AkademiQMongoDb.Dtos.TestimonialDto;
using AkademiQMongoDb.Entities;
using AutoMapper;

namespace AkademiQMongoDb.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetProductByIdDto>().ReverseMap();

            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialByIdDto>().ReverseMap();

            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetFeatureByIdDto>().ReverseMap();

            CreateMap<AboutSection1, ResultAbout1Dto>().ReverseMap();
            CreateMap<AboutSection1, CreateAbout1Dto>().ReverseMap();
            CreateMap<AboutSection1, UpdateAbout1Dto>().ReverseMap();
            CreateMap<AboutSection1, GetAbout1ByIdDto>().ReverseMap();

            CreateMap<SSS, ResultSSSDto>().ReverseMap();
            CreateMap<SSS, CreateSSSDto>().ReverseMap();
            CreateMap<SSS, UpdateSSSDto>().ReverseMap();
            CreateMap<SSS, GetSSSByIdDto>().ReverseMap();

            CreateMap<AboutSection2, ResultAbout2Dto>().ReverseMap();
            CreateMap<AboutSection2, CreateAbout2Dto>().ReverseMap();
            CreateMap<AboutSection2, UpdateAbout2Dto>().ReverseMap();
            CreateMap<AboutSection2, GetAbout2ByIdDto>().ReverseMap();

            CreateMap<StoryVideo, ResultVideoDto>().ReverseMap();
            CreateMap<StoryVideo, CreateVideoDto>().ReverseMap();
            CreateMap<StoryVideo, UpdateVideoDto>().ReverseMap();
            CreateMap<StoryVideo, GetVideoByIdDto>().ReverseMap();

            CreateMap<Order, ResultOrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();
            CreateMap<Order, GetByIdOrderDto>().ReverseMap();

            CreateMap<Subscriber, CreateSubscriberDto>().ReverseMap();
            CreateMap<Subscriber, ResultSubscriberDto>().ReverseMap();

            //Geriye kalan entity'leri sen yap
        }
    }
}
